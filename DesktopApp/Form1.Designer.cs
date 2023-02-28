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
            this.Register_tab = new System.Windows.Forms.TabPage();
            this.Login_tab = new System.Windows.Forms.TabPage();
            this.Review_tab = new System.Windows.Forms.TabPage();
            this.Reviews_screen = new System.Windows.Forms.ListBox();
            this.ReviewtxtBox = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ratingtxt = new System.Windows.Forms.TextBox();
            this.destinationsCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Review_tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Register_tab);
            this.tabControl1.Controls.Add(this.Login_tab);
            this.tabControl1.Controls.Add(this.Review_tab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 394);
            this.tabControl1.TabIndex = 0;
            // 
            // Register_tab
            // 
            this.Register_tab.Location = new System.Drawing.Point(4, 34);
            this.Register_tab.Name = "Register_tab";
            this.Register_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Register_tab.Size = new System.Drawing.Size(768, 356);
            this.Register_tab.TabIndex = 0;
            this.Register_tab.Text = "Register";
            this.Register_tab.UseVisualStyleBackColor = true;
            // 
            // Login_tab
            // 
            this.Login_tab.Location = new System.Drawing.Point(4, 34);
            this.Login_tab.Name = "Login_tab";
            this.Login_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Login_tab.Size = new System.Drawing.Size(768, 356);
            this.Login_tab.TabIndex = 1;
            this.Login_tab.Text = "Login";
            this.Login_tab.UseVisualStyleBackColor = true;
            // 
            // Review_tab
            // 
            this.Review_tab.Controls.Add(this.Reviews_screen);
            this.Review_tab.Controls.Add(this.ReviewtxtBox);
            this.Review_tab.Controls.Add(this.label3);
            this.Review_tab.Controls.Add(this.label1);
            this.Review_tab.Controls.Add(this.ratingtxt);
            this.Review_tab.Controls.Add(this.destinationsCb);
            this.Review_tab.Controls.Add(this.label2);
            this.Review_tab.Location = new System.Drawing.Point(4, 34);
            this.Review_tab.Name = "Review_tab";
            this.Review_tab.Size = new System.Drawing.Size(768, 356);
            this.Review_tab.TabIndex = 2;
            this.Review_tab.Text = "Review";
            this.Review_tab.UseVisualStyleBackColor = true;
            this.Review_tab.Click += new System.EventHandler(this.review_tab_Click);
            // 
            // Reviews_screen
            // 
            this.Reviews_screen.FormattingEnabled = true;
            this.Reviews_screen.ItemHeight = 25;
            this.Reviews_screen.Location = new System.Drawing.Point(468, 17);
            this.Reviews_screen.Name = "Reviews_screen";
            this.Reviews_screen.Size = new System.Drawing.Size(270, 279);
            this.Reviews_screen.TabIndex = 11;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.Review_tab.ResumeLayout(false);
            this.Review_tab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage Register_tab;
        private TabPage Login_tab;
        private TabPage Review_tab;
        private ListBox Reviews_screen;
        private RichTextBox ReviewtxtBox;
        private Label label3;
        private Label label1;
        private TextBox ratingtxt;
        private ComboBox destinationsCb;
        private Label label2;
    }
}