namespace DesktopApp
{
    partial class Login
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
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            loginBtn = new Button();
            registerBtn = new Button();
            passwordtxt = new TextBox();
            emailtxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1725, 539);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._6345959;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(400, 352);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(208, 247);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(112, 34);
            loginBtn.TabIndex = 5;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // registerBtn
            // 
            registerBtn.Location = new Point(265, 12);
            registerBtn.Name = "registerBtn";
            registerBtn.Size = new Size(112, 34);
            registerBtn.TabIndex = 6;
            registerBtn.Text = "Register";
            registerBtn.UseVisualStyleBackColor = true;
            // 
            // passwordtxt
            // 
            passwordtxt.Location = new Point(161, 174);
            passwordtxt.Name = "passwordtxt";
            passwordtxt.Size = new Size(208, 31);
            passwordtxt.TabIndex = 7;
            // 
            // emailtxt
            // 
            emailtxt.Location = new Point(161, 137);
            emailtxt.Name = "emailtxt";
            emailtxt.Size = new Size(208, 31);
            emailtxt.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 137);
            label1.Name = "label1";
            label1.Size = new Size(63, 25);
            label1.TabIndex = 9;
            label1.Text = "Email :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 180);
            label2.Name = "label2";
            label2.Size = new Size(96, 25);
            label2.TabIndex = 10;
            label2.Text = "Password :";
            // 
            // Login
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(400, 351);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(emailtxt);
            Controls.Add(passwordtxt);
            Controls.Add(registerBtn);
            Controls.Add(loginBtn);
            Controls.Add(pictureBox1);
            Controls.Add(textBox1);
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private PictureBox pictureBox1;
        private Button loginBtn;
        private Button registerBtn;
        private TextBox passwordtxt;
        private TextBox emailtxt;
        private Label label1;
        private Label label2;
    }
}