using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BasicDatabaseCRUD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            try
            {
                Program.connection.Open();
            }
            catch (Exception openEx)
            {
                MessageBox.Show("Database Connection Failure. Hit Ok to continue.");
            }
            InitializeComponent();
        }

        ~frmMain()
        {
            ///Closes database connection upon close.
            try
            {
                Program.connection.Close();
            }
            catch (Exception closeEx)
            {
                MessageBox.Show("Database close error. Hit Ok to continue.");
            }
        }

        public void ItemRefresh()
        {
            lstMenuItems2.Items.Clear();

            //Iterates through database to populate with entries
            try
            {
                OleDbDataReader reader = Database.SelectAllDb();
                while (reader.Read())
                {
                    lstMenuItems2.Items.Add(reader.GetString(0).ToString()).SubItems.Add(reader.GetInt32(1).ToString());
                }
                reader.Close();
            }
            catch (Exception readEx)
            {
                MessageBox.Show("Error in SelectAll. Hit Ok to continue.");
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ItemRefresh();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            addItem.ShowDialog();
            ItemRefresh();
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (lstMenuItems2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select an item to update.");
            }
            else
            {
                UpdateItem updateThis = new UpdateItem(lstMenuItems2.SelectedItems[0].SubItems[0].Text, lstMenuItems2.SelectedItems[0].SubItems[1].Text);
                updateThis.ShowDialog();
            }
            ItemRefresh();
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            try
            {
                Database.DeleteItem(lstMenuItems2.SelectedItems[0].SubItems[1].Text);
            }
            catch (Exception delEx)
            {
                MessageBox.Show("Error deleting item.");
            }
            ItemRefresh();
        }

        private void btnRefreshItems_Click(object sender, EventArgs e)
        {
            ItemRefresh();
        }
    }
}
