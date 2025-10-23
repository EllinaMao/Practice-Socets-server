namespace ServerForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sendBtn = new Button();
            richTextBox1 = new RichTextBox();
            listBox1 = new ListBox();
            textBoxIp = new TextBox();
            textBoxPort = new TextBox();
            startBtn = new Button();
            SuspendLayout();
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(12, 414);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(324, 23);
            sendBtn.TabIndex = 0;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 333);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(324, 73);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.HorizontalScrollbar = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 42);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(324, 274);
            listBox1.TabIndex = 2;
            // 
            // textBoxIp
            // 
            textBoxIp.Location = new Point(12, 12);
            textBoxIp.Name = "textBoxIp";
            textBoxIp.PlaceholderText = "ip aka 127.0.0.1";
            textBoxIp.Size = new Size(114, 23);
            textBoxIp.TabIndex = 3;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(132, 13);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.PlaceholderText = "port aka 4000";
            textBoxPort.Size = new Size(90, 23);
            textBoxPort.TabIndex = 4;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(228, 13);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(108, 23);
            startBtn.TabIndex = 5;
            startBtn.Text = "Start server";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 450);
            Controls.Add(startBtn);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxIp);
            Controls.Add(listBox1);
            Controls.Add(richTextBox1);
            Controls.Add(sendBtn);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendBtn;
        private RichTextBox richTextBox1;
        private ListBox listBox1;
        private TextBox textBoxIp;
        private TextBox textBoxPort;
        private Button startBtn;
    }
}
