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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Checks for blank, empty, or space entry
            if (textBox1.Text.ToString() == "" || textBox1.Text.ToString() == " " || textBox1.Text.ToString() == String.Empty)
            {
                MessageBox.Show("You entered an invalid entry.");
            }
            else
            {
                try
                {
                    Database.AddItem(textBox1.Text.ToString());
                }
                catch (Exception addEx)
                {
                    MessageBox.Show("Error adding an item. Hit Ok to continue.");
                }
                this.Close();
            }
        }
    }
}
