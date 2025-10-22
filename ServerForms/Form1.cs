namespace ServerForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += ChatForm_FormClosed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Примусово завершує весь процес
            Application.Exit();
        }
    }
}
