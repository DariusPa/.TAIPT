﻿namespace VirtualLibrarian
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
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.genreBox = new System.Windows.Forms.CheckedListBox();
            this.newAuthor = new System.Windows.Forms.Button();
            this.authorListBox = new System.Windows.Forms.ListBox();
            this.qtyBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.publisherListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(53, 48);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(70, 32);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(53, 100);
            this.authorLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(99, 32);
            this.authorLabel.TabIndex = 1;
            this.authorLabel.Text = "Author";
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Location = new System.Drawing.Point(53, 310);
            this.publisherLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(135, 32);
            this.publisherLabel.TabIndex = 2;
            this.publisherLabel.Text = "Publisher";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(58, 532);
            this.genreLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(94, 32);
            this.genreLabel.TabIndex = 3;
            this.genreLabel.Text = "Genre";
            // 
            // isbnLabel
            // 
            this.isbnLabel.AutoSize = true;
            this.isbnLabel.Location = new System.Drawing.Point(53, 732);
            this.isbnLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.isbnLabel.Name = "isbnLabel";
            this.isbnLabel.Size = new System.Drawing.Size(80, 32);
            this.isbnLabel.TabIndex = 4;
            this.isbnLabel.Text = "ISBN";
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(235, 48);
            this.titleBox.Margin = new System.Windows.Forms.Padding(5);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(721, 38);
            this.titleBox.TabIndex = 5;
            // 
            // isbnBox
            // 
            this.isbnBox.Location = new System.Drawing.Point(235, 729);
            this.isbnBox.Margin = new System.Windows.Forms.Padding(5);
            this.isbnBox.Name = "isbnBox";
            this.isbnBox.Size = new System.Drawing.Size(721, 38);
            this.isbnBox.TabIndex = 9;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(235, 781);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(5);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(721, 211);
            this.descriptionBox.TabIndex = 11;
            this.descriptionBox.Text = "";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(53, 781);
            this.descriptionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(158, 32);
            this.descriptionLabel.TabIndex = 11;
            this.descriptionLabel.Text = "Description";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(671, 1032);
            this.saveButton.Margin = new System.Windows.Forms.Padding(5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(285, 112);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveBook);
            // 
            // genreBox
            // 
            this.genreBox.CheckOnClick = true;
            this.genreBox.FormattingEnabled = true;
            this.genreBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.genreBox.Location = new System.Drawing.Point(238, 532);
            this.genreBox.Margin = new System.Windows.Forms.Padding(5);
            this.genreBox.Name = "genreBox";
            this.genreBox.Size = new System.Drawing.Size(721, 169);
            this.genreBox.TabIndex = 8;
            // 
            // newAuthor
            // 
            this.newAuthor.Location = new System.Drawing.Point(971, 155);
            this.newAuthor.Margin = new System.Windows.Forms.Padding(5);
            this.newAuthor.Name = "newAuthor";
            this.newAuthor.Size = new System.Drawing.Size(69, 81);
            this.newAuthor.TabIndex = 15;
            this.newAuthor.Text = "+";
            this.newAuthor.UseVisualStyleBackColor = true;
            this.newAuthor.Click += new System.EventHandler(this.newAuthor_Click);
            // 
            // authorListBox
            // 
            this.authorListBox.FormattingEnabled = true;
            this.authorListBox.ItemHeight = 31;
            this.authorListBox.Location = new System.Drawing.Point(232, 100);
            this.authorListBox.Margin = new System.Windows.Forms.Padding(5);
            this.authorListBox.Name = "authorListBox";
            this.authorListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.authorListBox.Size = new System.Drawing.Size(724, 190);
            this.authorListBox.TabIndex = 6;
            // 
            // qtyBox
            // 
            this.qtyBox.Location = new System.Drawing.Point(235, 1017);
            this.qtyBox.Name = "qtyBox";
            this.qtyBox.Size = new System.Drawing.Size(147, 38);
            this.qtyBox.TabIndex = 16;
            this.qtyBox.TextChanged += new System.EventHandler(this.qtyBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 1020);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Quantity";
            // 
            // publisherListBox
            // 
            this.publisherListBox.FormattingEnabled = true;
            this.publisherListBox.ItemHeight = 31;
            this.publisherListBox.Location = new System.Drawing.Point(235, 310);
            this.publisherListBox.Margin = new System.Windows.Forms.Padding(5);
            this.publisherListBox.Name = "publisherListBox";
            this.publisherListBox.Size = new System.Drawing.Size(724, 190);
            this.publisherListBox.TabIndex = 18;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1071, 1419);
            this.Controls.Add(this.publisherListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qtyBox);
            this.Controls.Add(this.authorListBox);
            this.Controls.Add(this.newAuthor);
            this.Controls.Add(this.genreBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.isbnBox);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.isbnLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.publisherLabel);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.titleLabel);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
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
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckedListBox genreBox;
        private System.Windows.Forms.Button newAuthor;
        private System.Windows.Forms.ListBox authorListBox;
        private System.Windows.Forms.TextBox qtyBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox publisherListBox;
    }
}