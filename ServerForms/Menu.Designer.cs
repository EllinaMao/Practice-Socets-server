namespace ServerForms
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            humanBtn = new Button();
            botBtn = new Button();
            SuspendLayout();
            // 
            // humanBtn
            // 
            humanBtn.Location = new Point(33, 64);
            humanBtn.Margin = new Padding(3, 4, 3, 4);
            humanBtn.Name = "humanBtn";
            humanBtn.Size = new Size(302, 31);
            humanBtn.TabIndex = 0;
            humanBtn.Text = "Im a Human";
            humanBtn.UseVisualStyleBackColor = true;
            humanBtn.Click += humanBtn_Click;
            // 
            // botBtn
            // 
            botBtn.Location = new Point(33, 115);
            botBtn.Margin = new Padding(3, 4, 3, 4);
            botBtn.Name = "botBtn";
            botBtn.Size = new Size(302, 31);
            botBtn.TabIndex = 1;
            botBtn.Text = "Im a Bot";
            botBtn.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 224);
            Controls.Add(botBtn);
            Controls.Add(humanBtn);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button humanBtn;
        private Button botBtn;
    }
}