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
            this.label1 = new System.Windows.Forms.Label();
            this.scanBox = new System.Windows.Forms.PictureBox();
            this.scanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scanBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(261, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // scanBox
            // 
            this.scanBox.Location = new System.Drawing.Point(49, 115);
            this.scanBox.Name = "scanBox";
            this.scanBox.Size = new System.Drawing.Size(567, 362);
            this.scanBox.TabIndex = 1;
            this.scanBox.TabStop = false;
            this.scanBox.Visible = false;
            this.scanBox.VisibleChanged += new System.EventHandler(this.scanBox_VisibleChanged);
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
            this.scanButton.Location = new System.Drawing.Point(269, 227);
            this.scanButton.Margin = new System.Windows.Forms.Padding(1);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(137, 126);
            this.scanButton.TabIndex = 6;
            this.scanButton.UseVisualStyleBackColor = false;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.scanBox);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Search";
            this.Size = new System.Drawing.Size(678, 509);
            this.Leave += new System.EventHandler(this.Search_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.scanBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox scanBox;
        private System.Windows.Forms.Button scanButton;
    }
}
