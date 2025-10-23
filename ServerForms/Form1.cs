//using BotAnswers; //ToDo - trasfer file
using Practice_Socets_server;
using System;

namespace ServerForms
{
    public partial class Form1 : Form
    {
        public readonly bool IsBot;
        private readonly SynchronizationContext? _uiContext;
        private Server? server;

        public Form1(bool isBot = false)
        {
            InitializeComponent();
            IsBot = isBot;
            _uiContext = SynchronizationContext.Current;
            this.FormClosed += ChatForm_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            richTextBox1.Enabled = false;
            sendBtn.Enabled = false;
            if (IsBot)
            {
                this.Text = "I`m s bot";
            }
            else
            {
                this.Text = "I`m a human";
            }

        }

        private void Server_OnClientConnected()
        {
            LogMessage("Client has connected.");

            if (!IsBot)
            {
                richTextBox1.Enabled = true;
                sendBtn.Enabled = true;
            }
        }

        private void Server_OnReceiveMessage(string message)
        {
            LogMessage($"Client: {message}");

            if (message.IndexOf(server.StopWord) > -1)
            {
                LogMessage("Client disconnected. Chat ended.");
                richTextBox1.Enabled = false;
                sendBtn.Enabled = false;
                return;
            }
            if (IsBot)
            {
                string reply = BotAnswers.ComputerAnswers.GetRandomAnswer();
                server.Send(reply);
                LogMessage($"Bot: {reply}");
            }
        }

        private void LogMessage(string message)
        {
            listBox1.Items.Add(message);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
        }

        private void ChatForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Примусово завершує весь процес
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = richTextBox1.Text;
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            server?.Send(message);
            LogMessage($"You: {message}");
            richTextBox1.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            server?.Send(server?.StopWord);

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (textBoxIp.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please, enter valid IP adress");
                return;
            }
            if (textBoxPort.Text.Trim().Length == 0)
            {
                MessageBox.Show("Please, enter valid port");
                return;
            }
            try
            {
                int port;
                if (!int.TryParse(textBoxPort.Text.Trim(), out port))
                {
                    MessageBox.Show("Please, enter a valid port number (e.g., 4000)");
                    return;
                }
                string ip = textBoxIp.Text.Trim();
                server = new Server(_uiContext);
                server.ClientConnected += Server_OnClientConnected;
                server.ServerLogMessage += Server_OnLogMessage; 
                server.ServerRecieveMessage += Server_OnReceiveMessage;
                Thread serverThread = new Thread(() => server.ThreadForAccept(ip, port));
                serverThread.IsBackground = true;
                serverThread.Start();

                startBtn.Enabled = false;
                textBoxIp.Enabled = false;
                textBoxPort.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while connecting: " + ex.Message);
            }
        }

        private void Server_OnLogMessage(string message)
        {
            LogMessage(message);
        }
    }
}
