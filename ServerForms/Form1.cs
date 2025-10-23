//using BotAnswers; //ToDo - trasfer file
using Practice_Socets_server;

namespace ServerForms
{
    public partial class Form1 : Form
    {
        public readonly bool IsBot;
        private readonly SynchronizationContext? _uiContext;
        private Server server;

        public Form1(bool isBot = false)
        {
            InitializeComponent();
            IsBot = isBot;
            _uiContext = SynchronizationContext.Current;


            this.FormClosed += ChatForm_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChatForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Примусово завершує весь процес
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
