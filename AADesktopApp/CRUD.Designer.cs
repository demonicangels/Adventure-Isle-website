namespace DesktopApp
{
    partial class CRUD
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
            this.CountryDestxt = new System.Windows.Forms.TextBox();
            this.descriptionDestxt = new System.Windows.Forms.RichTextBox();
            this.nameDestxt = new System.Windows.Forms.TextBox();
            this.currencyDestxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.GetAll_btn = new System.Windows.Forms.Button();
            this.Put_btn = new System.Windows.Forms.Button();
            this.Get_btn = new System.Windows.Forms.Button();
            this.Delete_btn = new System.Windows.Forms.Button();
            this.searchByIdtxt = new System.Windows.Forms.TextBox();
            this.desScreen = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // CountryDestxt
            // 
            this.CountryDestxt.Location = new System.Drawing.Point(176, 157);
            this.CountryDestxt.Name = "CountryDestxt";
            this.CountryDestxt.Size = new System.Drawing.Size(150, 31);
            this.CountryDestxt.TabIndex = 0;
            // 
            // descriptionDestxt
            // 
            this.descriptionDestxt.Location = new System.Drawing.Point(176, 282);
            this.descriptionDestxt.Name = "descriptionDestxt";
            this.descriptionDestxt.Size = new System.Drawing.Size(328, 183);
            this.descriptionDestxt.TabIndex = 1;
            this.descriptionDestxt.Text = "";
            // 
            // nameDestxt
            // 
            this.nameDestxt.Location = new System.Drawing.Point(176, 117);
            this.nameDestxt.Name = "nameDestxt";
            this.nameDestxt.Size = new System.Drawing.Size(150, 31);
            this.nameDestxt.TabIndex = 2;
            // 
            // currencyDestxt
            // 
            this.currencyDestxt.Location = new System.Drawing.Point(176, 204);
            this.currencyDestxt.Name = "currencyDestxt";
            this.currencyDestxt.Size = new System.Drawing.Size(150, 31);
            this.currencyDestxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(336, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(477, 77);
            this.label1.TabIndex = 5;
            this.label1.Text = "ADD DESTINATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Country";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Currency";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Brief description";
            // 
            // GetAll_btn
            // 
            this.GetAll_btn.Location = new System.Drawing.Point(392, 173);
            this.GetAll_btn.Name = "GetAll_btn";
            this.GetAll_btn.Size = new System.Drawing.Size(112, 64);
            this.GetAll_btn.TabIndex = 11;
            this.GetAll_btn.Text = "GetAll";
            this.GetAll_btn.UseVisualStyleBackColor = true;
            this.GetAll_btn.Click += new System.EventHandler(this.GetAll_btn_Click);
            // 
            // Put_btn
            // 
            this.Put_btn.Location = new System.Drawing.Point(392, 103);
            this.Put_btn.Name = "Put_btn";
            this.Put_btn.Size = new System.Drawing.Size(112, 64);
            this.Put_btn.TabIndex = 12;
            this.Put_btn.Text = "Insert";
            this.Put_btn.UseVisualStyleBackColor = true;
            this.Put_btn.Click += new System.EventHandler(this.Put_btn_Click);
            // 
            // Get_btn
            // 
            this.Get_btn.Location = new System.Drawing.Point(510, 171);
            this.Get_btn.Name = "Get_btn";
            this.Get_btn.Size = new System.Drawing.Size(112, 64);
            this.Get_btn.TabIndex = 13;
            this.Get_btn.Text = "Get";
            this.Get_btn.UseVisualStyleBackColor = true;
            this.Get_btn.Click += new System.EventHandler(this.Get_btn_Click);
            // 
            // Delete_btn
            // 
            this.Delete_btn.Location = new System.Drawing.Point(510, 103);
            this.Delete_btn.Name = "Delete_btn";
            this.Delete_btn.Size = new System.Drawing.Size(112, 64);
            this.Delete_btn.TabIndex = 14;
            this.Delete_btn.Text = "Delete";
            this.Delete_btn.UseVisualStyleBackColor = true;
            this.Delete_btn.Click += new System.EventHandler(this.Delete_btn_Click);
            // 
            // searchByIdtxt
            // 
            this.searchByIdtxt.Location = new System.Drawing.Point(510, 241);
            this.searchByIdtxt.Name = "searchByIdtxt";
            this.searchByIdtxt.Size = new System.Drawing.Size(112, 31);
            this.searchByIdtxt.TabIndex = 15;
            // 
            // desScreen
            // 
            this.desScreen.FormattingEnabled = true;
            this.desScreen.ItemHeight = 25;
            this.desScreen.Location = new System.Drawing.Point(651, 114);
            this.desScreen.Name = "desScreen";
            this.desScreen.Size = new System.Drawing.Size(451, 354);
            this.desScreen.TabIndex = 16;
            this.desScreen.Click += new System.EventHandler(this.desScreen_Click);
            // 
            // CRUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 477);
            this.Controls.Add(this.desScreen);
            this.Controls.Add(this.searchByIdtxt);
            this.Controls.Add(this.Delete_btn);
            this.Controls.Add(this.Get_btn);
            this.Controls.Add(this.Put_btn);
            this.Controls.Add(this.GetAll_btn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currencyDestxt);
            this.Controls.Add(this.nameDestxt);
            this.Controls.Add(this.descriptionDestxt);
            this.Controls.Add(this.CountryDestxt);
            this.Name = "CRUD";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox CountryDestxt;
        private RichTextBox descriptionDestxt;
        private TextBox nameDestxt;
        private TextBox currencyDestxt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Button GetAll_btn;
        private Button Put_btn;
        private Button Get_btn;
        private Button Delete_btn;
        private TextBox searchByIdtxt;
        private ListBox desScreen;
    }
}