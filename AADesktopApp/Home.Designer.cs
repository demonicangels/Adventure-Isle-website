namespace DesktopApp
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            pictureBox1 = new PictureBox();
            loginRegisterBtn = new PictureBox();
            TravellistButton = new PictureBox();
            destinationsButton = new PictureBox();
            label1 = new Label();
            textBox1 = new TextBox();
            searchBtn = new Button();
            profileBtn = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)loginRegisterBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TravellistButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)destinationsButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profileBtn).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.homepage;
            pictureBox1.Location = new Point(-3, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(806, 450);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // loginRegisterBtn
            // 
            loginRegisterBtn.Image = Properties.Resources.loginIcon;
            loginRegisterBtn.Location = new Point(12, 39);
            loginRegisterBtn.Name = "loginRegisterBtn";
            loginRegisterBtn.Size = new Size(97, 77);
            loginRegisterBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            loginRegisterBtn.TabIndex = 1;
            loginRegisterBtn.TabStop = false;
            loginRegisterBtn.Click += loginRegisterBtn_Click;
            // 
            // TravellistButton
            // 
            TravellistButton.Image = Properties.Resources.list;
            TravellistButton.Location = new Point(12, 138);
            TravellistButton.Name = "TravellistButton";
            TravellistButton.Size = new Size(97, 88);
            TravellistButton.SizeMode = PictureBoxSizeMode.StretchImage;
            TravellistButton.TabIndex = 2;
            TravellistButton.TabStop = false;
            TravellistButton.Click += pictureBox3_Click;
            // 
            // destinationsButton
            // 
            destinationsButton.Image = Properties.Resources.plane;
            destinationsButton.Location = new Point(12, 251);
            destinationsButton.Name = "destinationsButton";
            destinationsButton.Size = new Size(97, 90);
            destinationsButton.SizeMode = PictureBoxSizeMode.StretchImage;
            destinationsButton.TabIndex = 3;
            destinationsButton.TabStop = false;
            destinationsButton.Click += pictureBox4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 210);
            label1.Name = "label1";
            label1.Size = new Size(317, 25);
            label1.TabIndex = 4;
            label1.Text = "Discover your next favorite destination";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(512, 207);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(220, 31);
            textBox1.TabIndex = 5;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(675, 251);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(112, 34);
            searchBtn.TabIndex = 7;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // profileBtn
            // 
            profileBtn.Enabled = false;
            profileBtn.Image = (Image)resources.GetObject("profileBtn.Image");
            profileBtn.Location = new Point(12, 39);
            profileBtn.Name = "profileBtn";
            profileBtn.Size = new Size(97, 77);
            profileBtn.SizeMode = PictureBoxSizeMode.StretchImage;
            profileBtn.TabIndex = 8;
            profileBtn.TabStop = false;
            profileBtn.Visible = false;
            profileBtn.Click += profileBtn_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(profileBtn);
            Controls.Add(searchBtn);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(destinationsButton);
            Controls.Add(TravellistButton);
            Controls.Add(loginRegisterBtn);
            Controls.Add(pictureBox1);
            Name = "Home";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)loginRegisterBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)TravellistButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)destinationsButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)profileBtn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox loginRegisterBtn;
        private PictureBox TravellistButton;
        private PictureBox destinationsButton;
        private Label label1;
        private TextBox textBox1;
        private Button searchBtn;
        private PictureBox profileBtn;
    }
}