namespace FaceDB
{
    partial class RForm
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
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.surname_txtBox = new System.Windows.Forms.TextBox();
            this.name_lbl = new System.Windows.Forms.Label();
            this.surname_lbl = new System.Windows.Forms.Label();
            this.insert_btn = new System.Windows.Forms.Button();
            this.load_db = new System.Windows.Forms.Button();
            this.db_listView = new System.Windows.Forms.ListView();
            this.uid_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.surname_clmn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // name_txtbox
            // 
            this.name_txtbox.Location = new System.Drawing.Point(100, 112);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(100, 20);
            this.name_txtbox.TabIndex = 0;
            this.name_txtbox.TextChanged += new System.EventHandler(this.name_txtbox_TextChanged);
            // 
            // surname_txtBox
            // 
            this.surname_txtBox.Location = new System.Drawing.Point(100, 138);
            this.surname_txtBox.Name = "surname_txtBox";
            this.surname_txtBox.Size = new System.Drawing.Size(100, 20);
            this.surname_txtBox.TabIndex = 1;
            // 
            // name_lbl
            // 
            this.name_lbl.AutoSize = true;
            this.name_lbl.Location = new System.Drawing.Point(45, 112);
            this.name_lbl.Name = "name_lbl";
            this.name_lbl.Size = new System.Drawing.Size(35, 13);
            this.name_lbl.TabIndex = 2;
            this.name_lbl.Text = "Name";
            // 
            // surname_lbl
            // 
            this.surname_lbl.AutoSize = true;
            this.surname_lbl.Location = new System.Drawing.Point(45, 141);
            this.surname_lbl.Name = "surname_lbl";
            this.surname_lbl.Size = new System.Drawing.Size(49, 13);
            this.surname_lbl.TabIndex = 3;
            this.surname_lbl.Text = "Surname";
            // 
            // insert_btn
            // 
            this.insert_btn.Location = new System.Drawing.Point(125, 175);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(75, 23);
            this.insert_btn.TabIndex = 4;
            this.insert_btn.Text = "Insert to DB";
            this.insert_btn.UseVisualStyleBackColor = true;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // load_db
            // 
            this.load_db.Location = new System.Drawing.Point(215, 287);
            this.load_db.Name = "load_db";
            this.load_db.Size = new System.Drawing.Size(75, 23);
            this.load_db.TabIndex = 6;
            this.load_db.Text = "Load DB";
            this.load_db.UseVisualStyleBackColor = true;
            this.load_db.Click += new System.EventHandler(this.load_db_Click);
            // 
            // db_listView
            // 
            this.db_listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uid_clmn,
            this.name_clmn,
            this.surname_clmn});
            this.db_listView.Location = new System.Drawing.Point(347, 12);
            this.db_listView.Name = "db_listView";
            this.db_listView.Size = new System.Drawing.Size(422, 298);
            this.db_listView.TabIndex = 8;
            this.db_listView.UseCompatibleStateImageBehavior = false;
            this.db_listView.View = System.Windows.Forms.View.Details;
            // 
            // uid_clmn
            // 
            this.uid_clmn.Text = "UID";
            this.uid_clmn.Width = 180;
            // 
            // name_clmn
            // 
            this.name_clmn.Text = "Name";
            this.name_clmn.Width = 94;
            // 
            // surname_clmn
            // 
            this.surname_clmn.Text = "Surname";
            this.surname_clmn.Width = 143;
            // 
            // RForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 322);
            this.Controls.Add(this.db_listView);
            this.Controls.Add(this.load_db);
            this.Controls.Add(this.insert_btn);
            this.Controls.Add(this.surname_lbl);
            this.Controls.Add(this.name_lbl);
            this.Controls.Add(this.surname_txtBox);
            this.Controls.Add(this.name_txtbox);
            //this.Name = "RForm";
            this.Text = "Registration Form";
            this.Load += new System.EventHandler(this.RegForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name_txtbox;
        private System.Windows.Forms.TextBox surname_txtBox;
        private System.Windows.Forms.Label name_lbl;
        private System.Windows.Forms.Label surname_lbl;
        private System.Windows.Forms.Button insert_btn;
        private new System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.Button load_db;
        private System.Windows.Forms.ListView db_listView;
        private System.Windows.Forms.ColumnHeader uid_clmn;
        private System.Windows.Forms.ColumnHeader name_clmn;
        private System.Windows.Forms.ColumnHeader surname_clmn;
    }
}

