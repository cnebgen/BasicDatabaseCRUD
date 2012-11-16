using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace BasicDatabaseCRUD
{
    class Database
    {
        private static OleDbCommand selectAll;
        private static OleDbCommand deleteItem;
        private static OleDbCommand addItem;
        private static OleDbCommand updateItem;
        private static OleDbDataReader readerDb;

        public static OleDbDataReader SelectAllDb()
        {
            selectAll = new OleDbCommand("SELECT itemName, id FROM MenuItem;", Program.connection);
            OleDbDataReader readerDb = selectAll.ExecuteReader();
            return readerDb;
        }

        public static void DeleteItem(string id)
        {
            deleteItem = new OleDbCommand("DELETE FROM MenuItem WHERE id=" + id + ";", Program.connection);
            deleteItem.ExecuteNonQuery();
        }

        public static void AddItem(string itemName)
        {
            addItem = new OleDbCommand("INSERT INTO MenuItem (itemName) VALUES ('" + itemName + "');", Program.connection);
            addItem.ExecuteNonQuery();
        }

        public static void UpdateItem(string itemName, string id)
        {
            updateItem = new OleDbCommand("UPDATE MenuItem SET itemName='" + itemName + "' WHERE id=" + id + ";", Program.connection);
            updateItem.ExecuteNonQuery();
        }

    }
}