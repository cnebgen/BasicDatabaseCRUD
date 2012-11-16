using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BasicDatabaseCRUD
{
    public partial class UpdateItem : Form
    {
        /// <summary>
        /// Catches primary from main. Credit: Sead Soldner for this workaround.
        /// </summary>
        private string id;

        public UpdateItem(String itemName, String primary)
        {
            InitializeComponent();
            updateBox.Text = itemName;
            this.id = primary;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Error checking--checks for blank, empty, and space
            if (updateBox.Text.ToString() == "" || updateBox.Text.ToString() == " " || updateBox.Text.ToString() == String.Empty)
            {
                MessageBox.Show("You have input an invalid entry. Please try again.");
            }
            else
            {
                try
                {
                    Database.UpdateItem(updateBox.Text.ToString(), this.id);
                }
                catch (Exception updtEx)
                {
                    MessageBox.Show("Error updating item. Please click Ok to continue.");
                }
            }
            this.Close();
        }
    }
}
