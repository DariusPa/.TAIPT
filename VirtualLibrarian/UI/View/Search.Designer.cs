namespace VirtualLibrarian
{
    partial class Search
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
            this.searchLabel = new System.Windows.Forms.Label();
            this.libraryBooksGrid = new System.Windows.Forms.DataGridView();
            this.searchBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.libraryBooksGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.searchLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchLabel.Location = new System.Drawing.Point(523, 19);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(290, 89);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "Search";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // libraryBooksGrid
            // 
            this.libraryBooksGrid.AllowUserToAddRows = false;
            this.libraryBooksGrid.AllowUserToDeleteRows = false;
            this.libraryBooksGrid.AllowUserToResizeRows = false;
            this.libraryBooksGrid.BackgroundColor = System.Drawing.Color.White;
            this.libraryBooksGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.libraryBooksGrid.Location = new System.Drawing.Point(37, 190);
            this.libraryBooksGrid.MultiSelect = false;
            this.libraryBooksGrid.Name = "libraryBooksGrid";
            this.libraryBooksGrid.ReadOnly = true;
            this.libraryBooksGrid.RowTemplate.Height = 40;
            this.libraryBooksGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.libraryBooksGrid.Size = new System.Drawing.Size(1276, 761);
            this.libraryBooksGrid.TabIndex = 1;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(37, 132);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(1276, 38);
            this.searchBox.TabIndex = 2;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.libraryBooksGrid);
            this.Controls.Add(this.searchLabel);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(1355, 987);
            ((System.ComponentModel.ISupportInitialize)(this.libraryBooksGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.DataGridView libraryBooksGrid;
        private System.Windows.Forms.TextBox searchBox;
    }
}
