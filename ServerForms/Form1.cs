//using BotAnswers; //ToDo - trasfer file
using Practice_Socets_server;

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
            button1.Enabled = false;
            if (IsBot)
            {
                this.Text = "I`m s bot";
            }
            else
            {
                this.Text = "I`m a human";
            }
            server = new Server(_uiContext);
            server.ServerRecieveMessage += Server_ServerRecieveMessage;
            server.ClientConnected += Server_OnClientConnected;
            Thread serverThread = new Thread(() => server.ThreadForAccept());
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void Server_OnClientConnected()
        {
            LogMessage("Client has connected.");

            if (!IsBot)
            {
                richTextBox1.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void Server_ServerRecieveMessage(string message)
        {
            LogMessage(message);

            if (message.IndexOf(server.StopWord) > -1)
            {
                LogMessage("Client disconnected. Chat ended.");
                richTextBox1.Enabled = false;
                button1.Enabled = false;
                return;
            }
            if (IsBot)
            {
                // TODO: Переконайтеся, що клас BotAnswers додано до цього проєкту
                // string reply = BotAnswers.ComputerAnswers.GetRandomAnswer();
                string reply = "I am a bot, i received: " + message; // Тимчасова відповідь
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
    }
}
