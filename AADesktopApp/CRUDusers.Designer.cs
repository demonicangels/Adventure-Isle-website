namespace DesktopApp
{
    partial class CRUDusers
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
            this.label1 = new System.Windows.Forms.Label();
            this.usernameUsertxt = new System.Windows.Forms.TextBox();
            this.emailUsertxt = new System.Windows.Forms.TextBox();
            this.passwordUsertxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.userScreen = new System.Windows.Forms.ListBox();
            this.insert_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.getAll_btn = new System.Windows.Forms.Button();
            this.get_btn = new System.Windows.Forms.Button();
            this.searchByIdtxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(258, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 77);
            this.label1.TabIndex = 6;
            this.label1.Text = "ADD USER";
            // 
            // usernameUsertxt
            // 
            this.usernameUsertxt.Location = new System.Drawing.Point(122, 124);
            this.usernameUsertxt.Name = "usernameUsertxt";
            this.usernameUsertxt.Size = new System.Drawing.Size(150, 31);
            this.usernameUsertxt.TabIndex = 7;
            // 
            // emailUsertxt
            // 
            this.emailUsertxt.Location = new System.Drawing.Point(122, 161);
            this.emailUsertxt.Name = "emailUsertxt";
            this.emailUsertxt.Size = new System.Drawing.Size(150, 31);
            this.emailUsertxt.TabIndex = 8;
            // 
            // passwordUsertxt
            // 
            this.passwordUsertxt.Location = new System.Drawing.Point(122, 198);
            this.passwordUsertxt.Name = "passwordUsertxt";
            this.passwordUsertxt.Size = new System.Drawing.Size(150, 31);
            this.passwordUsertxt.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Password";
            // 
            // userScreen
            // 
            this.userScreen.FormattingEnabled = true;
            this.userScreen.ItemHeight = 25;
            this.userScreen.Location = new System.Drawing.Point(366, 105);
            this.userScreen.Name = "userScreen";
            this.userScreen.Size = new System.Drawing.Size(451, 354);
            this.userScreen.TabIndex = 17;
            this.userScreen.Click += new System.EventHandler(this.userScreen_Click);
            // 
            // insert_btn
            // 
            this.insert_btn.Location = new System.Drawing.Point(29, 254);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(112, 64);
            this.insert_btn.TabIndex = 18;
            this.insert_btn.Text = "Insert";
            this.insert_btn.UseVisualStyleBackColor = true;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(147, 254);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(112, 64);
            this.delete_btn.TabIndex = 19;
            this.delete_btn.Text = "Delete";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // getAll_btn
            // 
            this.getAll_btn.Location = new System.Drawing.Point(29, 324);
            this.getAll_btn.Name = "getAll_btn";
            this.getAll_btn.Size = new System.Drawing.Size(112, 64);
            this.getAll_btn.TabIndex = 20;
            this.getAll_btn.Text = "GetAll";
            this.getAll_btn.UseVisualStyleBackColor = true;
            this.getAll_btn.Click += new System.EventHandler(this.getAll_btn_Click);
            // 
            // get_btn
            // 
            this.get_btn.Location = new System.Drawing.Point(147, 324);
            this.get_btn.Name = "get_btn";
            this.get_btn.Size = new System.Drawing.Size(112, 64);
            this.get_btn.TabIndex = 21;
            this.get_btn.Text = "Get";
            this.get_btn.UseVisualStyleBackColor = true;
            this.get_btn.Click += new System.EventHandler(this.get_btn_Click);
            // 
            // searchByIdtxt
            // 
            this.searchByIdtxt.Location = new System.Drawing.Point(147, 394);
            this.searchByIdtxt.Name = "searchByIdtxt";
            this.searchByIdtxt.Size = new System.Drawing.Size(112, 31);
            this.searchByIdtxt.TabIndex = 22;
            // 
            // CRUDusers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 482);
            this.Controls.Add(this.searchByIdtxt);
            this.Controls.Add(this.get_btn);
            this.Controls.Add(this.getAll_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.insert_btn);
            this.Controls.Add(this.userScreen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordUsertxt);
            this.Controls.Add(this.emailUsertxt);
            this.Controls.Add(this.usernameUsertxt);
            this.Controls.Add(this.label1);
            this.Name = "CRUDusers";
            this.Text = "CRUDusers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox usernameUsertxt;
        private TextBox emailUsertxt;
        private TextBox passwordUsertxt;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox userScreen;
        private Button insert_btn;
        private Button delete_btn;
        private Button getAll_btn;
        private Button get_btn;
        private TextBox searchByIdtxt;
    }
}