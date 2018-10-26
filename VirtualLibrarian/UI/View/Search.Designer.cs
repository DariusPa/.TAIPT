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
            this.scanBox = new System.Windows.Forms.PictureBox();
            this.scanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scanBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.searchLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchLabel.Location = new System.Drawing.Point(196, 8);
            this.searchLabel.Margin = new System.Windows.Forms.Padding(0);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(115, 36);
            this.searchLabel.TabIndex = 0;
            this.searchLabel.Text = "Search";
            this.searchLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // scanBox
            // 
            this.scanBox.Location = new System.Drawing.Point(37, 93);
            this.scanBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scanBox.Name = "scanBox";
            this.scanBox.Size = new System.Drawing.Size(425, 294);
            this.scanBox.TabIndex = 1;
            this.scanBox.TabStop = false;
            this.scanBox.Visible = false;
            // 
            // scanButton
            // 
            this.scanButton.BackColor = System.Drawing.Color.Transparent;
            this.scanButton.BackgroundImage = global::VirtualLibrarian.Properties.Resources.QR;
            this.scanButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.scanButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(182)))), ((int)(((byte)(243)))));
            this.scanButton.FlatAppearance.BorderSize = 0;
            this.scanButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(152)))), ((int)(((byte)(230)))));
            this.scanButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(152)))), ((int)(((byte)(230)))));
            this.scanButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scanButton.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.scanButton.ForeColor = System.Drawing.Color.White;
            this.scanButton.Location = new System.Drawing.Point(202, 184);
            this.scanButton.Margin = new System.Windows.Forms.Padding(1);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(103, 102);
            this.scanButton.TabIndex = 6;
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.scanBox);
            this.Controls.Add(this.searchLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(508, 414);
            this.Leave += new System.EventHandler(this.Search_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.scanBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.PictureBox scanBox;
        private System.Windows.Forms.Button scanButton;
    }
}
