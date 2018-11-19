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
            this.scanButton = new System.Windows.Forms.Button();
            this.scanBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.scanBox)).BeginInit();
            this.SuspendLayout();
            // 
            // returnBookLabel
            // 
            this.returnBookLabel.AutoSize = true;
            this.returnBookLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBookLabel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.returnBookLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.returnBookLabel.Location = new System.Drawing.Point(387, 19);
            this.returnBookLabel.Margin = new System.Windows.Forms.Padding(0);
            this.returnBookLabel.Name = "returnBookLabel";
            this.returnBookLabel.Size = new System.Drawing.Size(537, 89);
            this.returnBookLabel.TabIndex = 1;
            this.returnBookLabel.Text = "Return a book";
            this.returnBookLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            this.scanButton.Location = new System.Drawing.Point(543, 406);
            this.scanButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(275, 243);
            this.scanButton.TabIndex = 10;
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // scanBox
            // 
            this.scanBox.Location = new System.Drawing.Point(103, 189);
            this.scanBox.Margin = new System.Windows.Forms.Padding(5);
            this.scanBox.Name = "scanBox";
            this.scanBox.Size = new System.Drawing.Size(1133, 701);
            this.scanBox.TabIndex = 9;
            this.scanBox.TabStop = false;
            this.scanBox.Visible = false;
            // 
            // ReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.scanBox);
            this.Controls.Add(this.returnBookLabel);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ReturnBook";
            this.Size = new System.Drawing.Size(1355, 987);
            ((System.ComponentModel.ISupportInitialize)(this.scanBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Leave += new System.EventHandler(this.ReturnBook_Leave);

        }

        #endregion

        private System.Windows.Forms.Label returnBookLabel;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.PictureBox scanBox;
    }
}
