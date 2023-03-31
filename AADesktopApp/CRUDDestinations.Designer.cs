namespace DesktopApp
{
    partial class CRUDDestinations
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
            descriptionDestxt = new RichTextBox();
            nameDestxt = new TextBox();
            currencyDestxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            GetAll_btn = new Button();
            Put_btn = new Button();
            Delete_btn = new Button();
            searchByIdtxt = new TextBox();
            desScreen = new ListBox();
            accDbFormbtn = new Button();
            Get_btn = new Button();
            label4 = new Label();
            climatetxt = new TextBox();
            countriesCb = new ComboBox();
            SuspendLayout();
            // 
            // descriptionDestxt
            // 
            descriptionDestxt.Location = new Point(176, 282);
            descriptionDestxt.Name = "descriptionDestxt";
            descriptionDestxt.Size = new Size(328, 183);
            descriptionDestxt.TabIndex = 1;
            descriptionDestxt.Text = "";
            // 
            // nameDestxt
            // 
            nameDestxt.Location = new Point(176, 94);
            nameDestxt.Name = "nameDestxt";
            nameDestxt.Size = new Size(182, 31);
            nameDestxt.TabIndex = 2;
            // 
            // currencyDestxt
            // 
            currencyDestxt.Location = new Point(176, 173);
            currencyDestxt.Name = "currencyDestxt";
            currencyDestxt.Size = new Size(182, 31);
            currencyDestxt.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe Print", 22F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(336, 9);
            label1.Name = "label1";
            label1.Size = new Size(477, 77);
            label1.TabIndex = 5;
            label1.Text = "ADD DESTINATION";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 100);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 6;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 142);
            label3.Name = "label3";
            label3.Size = new Size(75, 25);
            label3.TabIndex = 7;
            label3.Text = "Country";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(30, 179);
            label5.Name = "label5";
            label5.Size = new Size(81, 25);
            label5.TabIndex = 9;
            label5.Text = "Currency";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(30, 282);
            label6.Name = "label6";
            label6.Size = new Size(140, 25);
            label6.TabIndex = 10;
            label6.Text = "Brief description";
            // 
            // GetAll_btn
            // 
            GetAll_btn.Location = new Point(392, 173);
            GetAll_btn.Name = "GetAll_btn";
            GetAll_btn.Size = new Size(112, 64);
            GetAll_btn.TabIndex = 11;
            GetAll_btn.Text = "GetAll";
            GetAll_btn.UseVisualStyleBackColor = true;
            GetAll_btn.Click += GetAll_btn_Click;
            // 
            // Put_btn
            // 
            Put_btn.Location = new Point(392, 103);
            Put_btn.Name = "Put_btn";
            Put_btn.Size = new Size(112, 64);
            Put_btn.TabIndex = 12;
            Put_btn.Text = "Insert";
            Put_btn.UseVisualStyleBackColor = true;
            Put_btn.Click += Put_btn_Click;
            // 
            // Delete_btn
            // 
            Delete_btn.Location = new Point(510, 103);
            Delete_btn.Name = "Delete_btn";
            Delete_btn.Size = new Size(112, 64);
            Delete_btn.TabIndex = 14;
            Delete_btn.Text = "Delete";
            Delete_btn.UseVisualStyleBackColor = true;
            Delete_btn.Click += Delete_btn_Click;
            // 
            // searchByIdtxt
            // 
            searchByIdtxt.Location = new Point(510, 241);
            searchByIdtxt.Name = "searchByIdtxt";
            searchByIdtxt.Size = new Size(112, 31);
            searchByIdtxt.TabIndex = 15;
            // 
            // desScreen
            // 
            desScreen.FormattingEnabled = true;
            desScreen.ItemHeight = 25;
            desScreen.Location = new Point(651, 114);
            desScreen.Name = "desScreen";
            desScreen.Size = new Size(451, 354);
            desScreen.TabIndex = 16;
            desScreen.Click += desScreen_Click;
            // 
            // accDbFormbtn
            // 
            accDbFormbtn.Location = new Point(909, 74);
            accDbFormbtn.Name = "accDbFormbtn";
            accDbFormbtn.Size = new Size(193, 34);
            accDbFormbtn.TabIndex = 17;
            accDbFormbtn.Text = "account managment";
            accDbFormbtn.UseVisualStyleBackColor = true;
            accDbFormbtn.Click += accDbFormbtn_Click;
            // 
            // Get_btn
            // 
            Get_btn.Location = new Point(510, 171);
            Get_btn.Name = "Get_btn";
            Get_btn.Size = new Size(112, 64);
            Get_btn.TabIndex = 13;
            Get_btn.Text = "Get";
            Get_btn.UseVisualStyleBackColor = true;
            Get_btn.Click += Get_btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 216);
            label4.Name = "label4";
            label4.Size = new Size(71, 25);
            label4.TabIndex = 18;
            label4.Text = "Climate";
            // 
            // climatetxt
            // 
            climatetxt.Location = new Point(176, 210);
            climatetxt.Name = "climatetxt";
            climatetxt.Size = new Size(182, 31);
            climatetxt.TabIndex = 19;
            // 
            // countriesCb
            // 
            countriesCb.FormattingEnabled = true;
            countriesCb.Items.AddRange(new object[] { "France,", "Italy" });
            countriesCb.Location = new Point(176, 134);
            countriesCb.Name = "countriesCb";
            countriesCb.Size = new Size(182, 33);
            countriesCb.TabIndex = 20;
            // 
            // CRUDDestinations
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 477);
            Controls.Add(countriesCb);
            Controls.Add(climatetxt);
            Controls.Add(label4);
            Controls.Add(accDbFormbtn);
            Controls.Add(desScreen);
            Controls.Add(searchByIdtxt);
            Controls.Add(Delete_btn);
            Controls.Add(Get_btn);
            Controls.Add(Put_btn);
            Controls.Add(GetAll_btn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(currencyDestxt);
            Controls.Add(nameDestxt);
            Controls.Add(descriptionDestxt);
            Name = "CRUDDestinations";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Button Delete_btn;
        private TextBox searchByIdtxt;
        private ListBox desScreen;
        private Button accDbFormbtn;
        private Button Get_btn;
        private Label label4;
        private TextBox climatetxt;
        private ComboBox countriesCb;
    }
}