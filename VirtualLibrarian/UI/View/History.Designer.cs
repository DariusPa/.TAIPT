namespace VirtualLibrarian
{
    partial class History
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
            this.label1 = new System.Windows.Forms.Label();
            this.historyDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(525, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 89);
            this.label1.TabIndex = 2;
            this.label1.Text = "History";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // historyDataGrid
            // 
            this.historyDataGrid.AllowUserToAddRows = false;
            this.historyDataGrid.AllowUserToDeleteRows = false;
            this.historyDataGrid.AllowUserToResizeRows = false;
            this.historyDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historyDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.historyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.historyDataGrid.Location = new System.Drawing.Point(59, 148);
            this.historyDataGrid.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.historyDataGrid.MultiSelect = false;
            this.historyDataGrid.Name = "historyDataGrid";
            this.historyDataGrid.ReadOnly = true;
            this.historyDataGrid.RowTemplate.Height = 24;
            this.historyDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyDataGrid.ShowEditingIcon = false;
            this.historyDataGrid.Size = new System.Drawing.Size(1187, 744);
            this.historyDataGrid.TabIndex = 3;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.historyDataGrid);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "History";
            this.Size = new System.Drawing.Size(1355, 987);
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView historyDataGrid;
    }
}
