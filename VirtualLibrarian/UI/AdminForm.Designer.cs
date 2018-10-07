namespace VirtualLibrarian
{
    partial class AdminForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.isbnBox = new System.Windows.Forms.TextBox();
            this.authorBox = new System.Windows.Forms.ComboBox();
            this.publisherBox = new System.Windows.Forms.TextBox();
            this.genreBox = new System.Windows.Forms.ComboBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.barcodeBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Publisher";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Genre";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "ISBN";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(134, 66);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(363, 22);
            this.titleBox.TabIndex = 5;
            // 
            // isbnBox
            // 
            this.isbnBox.Location = new System.Drawing.Point(134, 244);
            this.isbnBox.Name = "isbnBox";
            this.isbnBox.Size = new System.Drawing.Size(363, 22);
            this.isbnBox.TabIndex = 6;
            // 
            // authorBox
            // 
            this.authorBox.FormattingEnabled = true;
            this.authorBox.Location = new System.Drawing.Point(134, 112);
            this.authorBox.Name = "authorBox";
            this.authorBox.Size = new System.Drawing.Size(363, 24);
            this.authorBox.TabIndex = 7;
            this.authorBox.Tag = " ";
            this.authorBox.Enter += new System.EventHandler(this.authorBox_Enter);
            // 
            // publisherBox
            // 
            this.publisherBox.Location = new System.Drawing.Point(134, 156);
            this.publisherBox.Name = "publisherBox";
            this.publisherBox.Size = new System.Drawing.Size(363, 22);
            this.publisherBox.TabIndex = 8;
            // 
            // genreBox
            // 
            this.genreBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.Location = new System.Drawing.Point(134, 200);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(363, 24);
            this.genreBox.TabIndex = 9;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(134, 288);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(363, 153);
            this.descriptionBox.TabIndex = 10;
            this.descriptionBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Description";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(354, 591);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 58);
            this.button2.TabIndex = 13;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // barcodeBox
            // 
            this.barcodeBox.Location = new System.Drawing.Point(134, 454);
            this.barcodeBox.Name = "barcodeBox";
            this.barcodeBox.Size = new System.Drawing.Size(363, 118);
            this.barcodeBox.TabIndex = 14;
            this.barcodeBox.TabStop = false;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 692);
            this.Controls.Add(this.barcodeBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.genreBox);
            this.Controls.Add(this.publisherBox);
            this.Controls.Add(this.authorBox);
            this.Controls.Add(this.isbnBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox isbnBox;
        private System.Windows.Forms.ComboBox authorBox;
        private System.Windows.Forms.TextBox publisherBox;
        private System.Windows.Forms.ComboBox genreBox;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox barcodeBox;
    }
}