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
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.isbnLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.isbnBox = new System.Windows.Forms.TextBox();
            this.publisherBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.barcodeBox = new System.Windows.Forms.PictureBox();
            this.genreBox = new System.Windows.Forms.CheckedListBox();
            this.newAuthor = new System.Windows.Forms.Button();
            this.authorListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(27, 24);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(35, 17);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(27, 52);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(50, 17);
            this.authorLabel.TabIndex = 1;
            this.authorLabel.Text = "Author";
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Location = new System.Drawing.Point(27, 160);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(67, 17);
            this.publisherLabel.TabIndex = 2;
            this.publisherLabel.Text = "Publisher";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(27, 188);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(48, 17);
            this.genreLabel.TabIndex = 3;
            this.genreLabel.Text = "Genre";
            // 
            // isbnLabel
            // 
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Location = new System.Drawing.Point(29, 288);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(39, 17);
            this.isbnLabel.TabIndex = 4;
            this.isbnLabel.Text = "ISBN";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(118, 24);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(363, 22);
            this.titleBox.TabIndex = 5;
            // 
            // isbnBox
            // 
            this.isbnBox.Location = new System.Drawing.Point(118, 300);
            this.isbnBox.Name = "isbnBox";
            this.isbnBox.Size = new System.Drawing.Size(363, 22);
            this.isbnBox.TabIndex = 9;
            // 
            // publisherBox
            // 
            this.publisherBox.Location = new System.Drawing.Point(117, 160);
            this.publisherBox.Name = "publisherBox";
            this.publisherBox.Size = new System.Drawing.Size(363, 22);
            this.publisherBox.TabIndex = 7;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(118, 328);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(363, 111);
            this.descriptionBox.TabIndex = 11;
            this.descriptionBox.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(27, 328);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(79, 17);
            this.descriptionLabel.TabIndex = 11;
            this.descriptionLabel.Text = "Description";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(338, 510);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(143, 58);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveBook);
            // 
            // barcodeBox
            // 
            this.barcodeBox.Location = new System.Drawing.Point(118, 455);
            this.barcodeBox.Name = "barcodeBox";
            this.barcodeBox.Size = new System.Drawing.Size(155, 123);
            this.barcodeBox.TabIndex = 14;
            this.barcodeBox.TabStop = false;
            // 
            // genreBox
            // 
            this.genreBox.CheckOnClick = true;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.genreBox.Location = new System.Drawing.Point(117, 188);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(363, 106);
            this.genreBox.TabIndex = 8;
            // 
            // newAuthor
            // 
            this.newAuthor.Location = new System.Drawing.Point(486, 80);
            this.newAuthor.Name = "newAuthor";
            this.newAuthor.Size = new System.Drawing.Size(34, 42);
            this.newAuthor.TabIndex = 15;
            this.newAuthor.Text = "+";
            this.newAuthor.UseVisualStyleBackColor = true;
            this.newAuthor.Click += new System.EventHandler(this.newAuthor_Click);
            // 
            // authorListBox
            // 
            this.authorListBox.FormattingEnabled = true;
            this.authorListBox.ItemHeight = 16;
            this.authorListBox.Location = new System.Drawing.Point(116, 52);
            this.authorListBox.Name = "authorListBox";
            this.authorListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.authorListBox.Size = new System.Drawing.Size(364, 100);
            this.authorListBox.TabIndex = 6;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 590);
            this.Controls.Add(this.authorListBox);
            this.Controls.Add(this.newAuthor);
            this.Controls.Add(this.genreBox);
            this.Controls.Add(this.barcodeBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.publisherBox);
            this.Controls.Add(this.isbnBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.isbnLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.publisherLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label isbnLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.TextBox isbnBox;
        private System.Windows.Forms.TextBox publisherBox;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox barcodeBox;
        private System.Windows.Forms.CheckedListBox genreBox;
        private System.Windows.Forms.Button newAuthor;
        private System.Windows.Forms.ListBox authorListBox;
    }
}