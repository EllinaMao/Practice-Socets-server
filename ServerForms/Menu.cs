using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerForms
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void humanBtn_Click(object sender, EventArgs e)
        {
            OpenChatForm(false);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            OpenChatForm(true);
        }
        private void OpenChatForm(bool isBot)
        {
            Form1 chatWindow = new Form1(isBot);
            chatWindow.Show();
            this.Hide();
        }
    }
}
