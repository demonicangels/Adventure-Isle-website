namespace DesktopApp
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.register_tab = new System.Windows.Forms.TabPage();
            this.register_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.login_tab = new System.Windows.Forms.TabPage();
            this.login_button = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.loginPasswordtxt = new System.Windows.Forms.TextBox();
            this.loginUsernametxt = new System.Windows.Forms.TextBox();
            this.review_tab = new System.Windows.Forms.TabPage();
            this.review_btn = new System.Windows.Forms.Button();
            this.Reviews_screen = new System.Windows.Forms.ListBox();
            this.ReviewtxtBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ratingtxt = new System.Windows.Forms.TextBox();
            this.destinationsCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.travellist_tab = new System.Windows.Forms.TabPage();
            this.addBtn = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.travellistScreen = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.register_tab.SuspendLayout();
            this.login_tab.SuspendLayout();
            this.review_tab.SuspendLayout();
            this.travellist_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.register_tab);
            this.tabControl1.Controls.Add(this.login_tab);
            this.tabControl1.Controls.Add(this.review_tab);
            this.tabControl1.Controls.Add(this.travellist_tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 421);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // register_tab
            // 
            this.register_tab.Controls.Add(this.button1);
            this.register_tab.Controls.Add(this.register_button);
            this.register_tab.Controls.Add(this.label6);
            this.register_tab.Controls.Add(this.label5);
            this.register_tab.Controls.Add(this.label4);
            this.register_tab.Controls.Add(this.passwordtxt);
            this.register_tab.Controls.Add(this.emailtxt);
            this.register_tab.Controls.Add(this.usernametxt);
            this.register_tab.Location = new System.Drawing.Point(4, 34);
            this.register_tab.Name = "register_tab";
            this.register_tab.Padding = new System.Windows.Forms.Padding(3);
            this.register_tab.Size = new System.Drawing.Size(768, 383);
            this.register_tab.TabIndex = 0;
            this.register_tab.Text = "Register";
            this.register_tab.UseVisualStyleBackColor = true;
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(285, 197);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(112, 34);
            this.register_button.TabIndex = 6;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username";
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(138, 146);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(150, 31);
            this.passwordtxt.TabIndex = 2;
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(138, 109);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(150, 31);
            this.emailtxt.TabIndex = 1;
            // 
            // usernametxt
            // 
            this.usernametxt.Location = new System.Drawing.Point(138, 72);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(150, 31);
            this.usernametxt.TabIndex = 0;
            // 
            // login_tab
            // 
            this.login_tab.Controls.Add(this.login_button);
            this.login_tab.Controls.Add(this.label8);
            this.login_tab.Controls.Add(this.label7);
            this.login_tab.Controls.Add(this.loginPasswordtxt);
            this.login_tab.Controls.Add(this.loginUsernametxt);
            this.login_tab.Location = new System.Drawing.Point(4, 34);
            this.login_tab.Name = "login_tab";
            this.login_tab.Padding = new System.Windows.Forms.Padding(3);
            this.login_tab.Size = new System.Drawing.Size(768, 383);
            this.login_tab.TabIndex = 1;
            this.login_tab.Text = "Login";
            this.login_tab.UseVisualStyleBackColor = true;
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(289, 158);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(112, 34);
            this.login_button.TabIndex = 7;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 25);
            this.label8.TabIndex = 6;
            this.label8.Text = "Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 25);
            this.label7.TabIndex = 4;
            this.label7.Text = "Username";
            // 
            // loginPasswordtxt
            // 
            this.loginPasswordtxt.Location = new System.Drawing.Point(131, 113);
            this.loginPasswordtxt.Name = "loginPasswordtxt";
            this.loginPasswordtxt.Size = new System.Drawing.Size(150, 31);
            this.loginPasswordtxt.TabIndex = 3;
            // 
            // loginUsernametxt
            // 
            this.loginUsernametxt.Location = new System.Drawing.Point(131, 67);
            this.loginUsernametxt.Name = "loginUsernametxt";
            this.loginUsernametxt.Size = new System.Drawing.Size(150, 31);
            this.loginUsernametxt.TabIndex = 1;
            // 
            // review_tab
            // 
            this.review_tab.Controls.Add(this.review_btn);
            this.review_tab.Controls.Add(this.Reviews_screen);
            this.review_tab.Controls.Add(this.ReviewtxtBox);
            this.review_tab.Controls.Add(this.label3);
            this.review_tab.Controls.Add(this.label1);
            this.review_tab.Controls.Add(this.ratingtxt);
            this.review_tab.Controls.Add(this.destinationsCb);
            this.review_tab.Controls.Add(this.label2);
            this.review_tab.Location = new System.Drawing.Point(4, 34);
            this.review_tab.Name = "review_tab";
            this.review_tab.Size = new System.Drawing.Size(768, 383);
            this.review_tab.TabIndex = 2;
            this.review_tab.Text = "Review";
            this.review_tab.UseVisualStyleBackColor = true;
            // 
            // review_btn
            // 
            this.review_btn.Location = new System.Drawing.Point(588, 327);
            this.review_btn.Name = "review_btn";
            this.review_btn.Size = new System.Drawing.Size(150, 41);
            this.review_btn.TabIndex = 12;
            this.review_btn.Text = "Review";
            this.review_btn.UseVisualStyleBackColor = true;
            this.review_btn.Click += new System.EventHandler(this.review_btn_Click);
            // 
            // Reviews_screen
            // 
            this.Reviews_screen.FormattingEnabled = true;
            this.Reviews_screen.ItemHeight = 25;
            this.Reviews_screen.Location = new System.Drawing.Point(468, 17);
            this.Reviews_screen.Name = "Reviews_screen";
            this.Reviews_screen.Size = new System.Drawing.Size(270, 279);
            this.Reviews_screen.TabIndex = 11;
            this.Reviews_screen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Reviews_screen_MouseClick);
            // 
            // ReviewtxtBox
            // 
            this.ReviewtxtBox.Location = new System.Drawing.Point(143, 142);
            this.ReviewtxtBox.Name = "ReviewtxtBox";
            this.ReviewtxtBox.Size = new System.Drawing.Size(289, 144);
            this.ReviewtxtBox.TabIndex = 10;
            this.ReviewtxtBox.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Your review";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Your rating (from 5 stars)";
            // 
            // ratingtxt
            // 
            this.ratingtxt.Location = new System.Drawing.Point(250, 89);
            this.ratingtxt.Name = "ratingtxt";
            this.ratingtxt.Size = new System.Drawing.Size(182, 31);
            this.ratingtxt.TabIndex = 7;
            // 
            // destinationsCb
            // 
            this.destinationsCb.FormattingEnabled = true;
            this.destinationsCb.Location = new System.Drawing.Point(250, 41);
            this.destinationsCb.Name = "destinationsCb";
            this.destinationsCb.Size = new System.Drawing.Size(182, 33);
            this.destinationsCb.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Choose a destination ";
            // 
            // travellist_tab
            // 
            this.travellist_tab.Controls.Add(this.addBtn);
            this.travellist_tab.Controls.Add(this.checkBox5);
            this.travellist_tab.Controls.Add(this.checkBox4);
            this.travellist_tab.Controls.Add(this.checkBox3);
            this.travellist_tab.Controls.Add(this.checkBox2);
            this.travellist_tab.Controls.Add(this.checkBox1);
            this.travellist_tab.Controls.Add(this.label9);
            this.travellist_tab.Controls.Add(this.travellistScreen);
            this.travellist_tab.Location = new System.Drawing.Point(4, 34);
            this.travellist_tab.Name = "travellist_tab";
            this.travellist_tab.Padding = new System.Windows.Forms.Padding(3);
            this.travellist_tab.Size = new System.Drawing.Size(768, 383);
            this.travellist_tab.TabIndex = 4;
            this.travellist_tab.Text = "Travel list";
            this.travellist_tab.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(14, 321);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(255, 34);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(20, 156);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(117, 29);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "Blowdryer";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(20, 121);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(90, 29);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "Towels";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(20, 86);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(54, 29);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "Id";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(20, 51);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(56, 29);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "nz";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 16);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 29);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "d";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Vivaldi", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(375, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(247, 57);
            this.label9.TabIndex = 1;
            this.label9.Text = "My travel list";
            // 
            // travellistScreen
            // 
            this.travellistScreen.FormattingEnabled = true;
            this.travellistScreen.ItemHeight = 25;
            this.travellistScreen.Location = new System.Drawing.Point(275, 76);
            this.travellistScreen.Name = "travellistScreen";
            this.travellistScreen.Size = new System.Drawing.Size(468, 279);
            this.travellistScreen.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(638, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 32);
            this.label10.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DesktopApp.Properties.Resources.anonymous;
            this.pictureBox1.Location = new System.Drawing.Point(710, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.register_tab.ResumeLayout(false);
            this.register_tab.PerformLayout();
            this.login_tab.ResumeLayout(false);
            this.login_tab.PerformLayout();
            this.review_tab.ResumeLayout(false);
            this.review_tab.PerformLayout();
            this.travellist_tab.ResumeLayout(false);
            this.travellist_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TabControl tabControl1;
        private TabPage register_tab;
        private TabPage login_tab;
        private TabPage review_tab;
        private ListBox Reviews_screen;
        private RichTextBox ReviewtxtBox;
        private Label label3;
        private Label label1;
        private TextBox ratingtxt;
        private ComboBox destinationsCb;
        private Label label2;
        private Button register_button;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox passwordtxt;
        private TextBox emailtxt;
        private TextBox usernametxt;
        private Button login_button;
        private Label label8;
        private Label label7;
        private TextBox loginPasswordtxt;
        private TextBox loginUsernametxt;
        private Button review_btn;
        private Label label10;
        private PictureBox pictureBox1;
        private TabPage travellist_tab;
        private Button addBtn;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Label label9;
        private ListBox travellistScreen;
        private Button button1;
    }
}