using System;
using System.Collections; //ADD THIS TO USE AN ARRAY LIST
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CareActerVS
{
    class Item
    {
        String name;
        String description;


        public Item(String n, String d)
        {
            name = n;
            description = n;
        }

        public Item()
        {

        }

        public String getItemName()
        {
            return name;
        }

        public String getItemDesc()
        {
            return description;
        }

        public static ArrayList getItemList(string characterName)
        {
            ArrayList itemList = new ArrayList();  //a list to save the items
            //prepare an SQL query to retrieve all the items for the same character
            DataTable myTable = new DataTable();
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM bms_items WHERE `Character Name` LIKE @character";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@character", characterName);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to item and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Item newItem = new Item
                {
                    name = row["Item Name"].ToString(),
                    description = row["Item Description"].ToString()
                };
                itemList.Add(newItem);
            }
            return itemList;  //return the item list
        }

        public static void saveItem(String itemName, String itemDescription, String characterName)
        {
            // saving a new item with add
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO bms_items (`Item Name`, `Item Description`, `Character Name`) " +
                    "VALUES (@name, @description, @character)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", itemName);
                cmd.Parameters.AddWithValue("@description", itemDescription);
                cmd.Parameters.AddWithValue("@character", characterName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }

        public static void editItem(String itemName, String itemDescription, String oldName)
        {
            // edit item in database
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE bms_items SET `Item Name` = @name, `Item Description` = @description WHERE `Item Name` = @oldN;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", itemName);
                cmd.Parameters.AddWithValue("@description", itemDescription);
                cmd.Parameters.AddWithValue("@oldN", oldName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

        public static void deleteItem(string itemName)
        {

            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM bms_items WHERE `Item Name` = @name;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", itemName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
    }
}
