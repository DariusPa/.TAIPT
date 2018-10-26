namespace VirtualLibrarian
{
    partial class ReturnBook
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.returnBookLabel = new System.Windows.Forms.Label();
            this.bookListDataGrid = new System.Windows.Forms.DataGridView();
            this.returnButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookListDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // returnBookLabel
            // 
            this.returnBookLabel.AutoSize = true;
            this.returnBookLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBookLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.returnBookLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.returnBookLabel.Location = new System.Drawing.Point(145, 8);
            this.returnBookLabel.Margin = new System.Windows.Forms.Padding(0);
            this.returnBookLabel.Name = "returnBookLabel";
            this.returnBookLabel.Size = new System.Drawing.Size(213, 36);
            this.returnBookLabel.TabIndex = 1;
            this.returnBookLabel.Text = "Return a book";
            this.returnBookLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // bookListDataGrid
            // 
            this.bookListDataGrid.AllowUserToAddRows = false;
            this.bookListDataGrid.AllowUserToDeleteRows = false;
            this.bookListDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bookListDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.bookListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookListDataGrid.Location = new System.Drawing.Point(32, 70);
            this.bookListDataGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bookListDataGrid.Name = "bookListDataGrid";
            this.bookListDataGrid.RowTemplate.Height = 24;
            this.bookListDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bookListDataGrid.Size = new System.Drawing.Size(444, 274);
            this.bookListDataGrid.TabIndex = 4;
            // 
            // returnButton
            // 
            this.returnButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(129)))), ((int)(((byte)(156)))));
            this.returnButton.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnButton.ForeColor = System.Drawing.Color.White;
            this.returnButton.Location = new System.Drawing.Point(151, 360);
            this.returnButton.Margin = new System.Windows.Forms.Padding(2);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(194, 41);
            this.returnButton.TabIndex = 5;
            this.returnButton.Text = "RETURN SELECTED";
            this.returnButton.UseVisualStyleBackColor = false;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.bookListDataGrid);
            this.Controls.Add(this.returnBookLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReturnBook";
            this.Size = new System.Drawing.Size(508, 414);
            ((System.ComponentModel.ISupportInitialize)(this.bookListDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label returnBookLabel;
        private System.Windows.Forms.DataGridView bookListDataGrid;
        private System.Windows.Forms.Button returnButton;
    }
}
