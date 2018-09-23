using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceDB
{
    public partial class RForm : Form
    {
        public RForm()
        {
            InitializeComponent();
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void load_db_Click(object sender, EventArgs e)
        {
            PostGreSQL pg = new PostGreSQL();
            List<string> guidItems = pg.GetUidList();
            List<string> nameItems = pg.GetNameList();
            List<string> surnameItems = pg.GetSurnameList();

            db_listView.Items.Clear();
            for (int i = 0; i < guidItems.Count; i++)
            {
                ListViewItem item = new ListViewItem(guidItems[i]);
                item.SubItems.Add(nameItems[i]);
                item.SubItems.Add(surnameItems[i]);
                db_listView.Items.Add(item);
            } 

        }

        private void insert_btn_Click(object sender, EventArgs e)
        {
            PostGreSQL pg = new PostGreSQL();
            string name = name_txtbox.Text;
            string surname = surname_txtBox.Text;
            pg.InsertData(name, surname);
        }

        private void name_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void db_listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
