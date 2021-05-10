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
    class Skill
    {
        String name;
        String description;


        public Skill(String n, String d)
        {
            name = n;
            description = n;
        }

        public Skill()
        {

        }

        public String getSkillName()
        {
            return name;
        }

        public String getSkillDesc()
        {
            return description;
        }

        public static ArrayList getSkillList(string characterName)
        {
            ArrayList skillList = new ArrayList();  //a list to save the skills
            //prepare an SQL query to retrieve all the skills for the same character
            DataTable myTable = new DataTable();
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM bms_skills WHERE `Character Name` LIKE @character";
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
                Skill newSkill = new Skill
                {
                    name = row["Skill Name"].ToString(),
                    description = row["Skill Description"].ToString()
                };
                skillList.Add(newSkill);
            }
            return skillList;  //return the skill list
        }

        public static void saveSkill(String skillName, String skillDescription, String characterName)
        {
            // saving a new item with add
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO bms_skills (`Skill Name`, `Skill Description`, `Character Name`) " +
                    "VALUES (@name, @description, @character)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", skillName);
                cmd.Parameters.AddWithValue("@description", skillDescription);
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

        public static void editSkills(String skillName, String skillDescription, String oldName)
        {
            // edit skill in database
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE bms_skills SET `Skill Name` = @name, `Skill Description` = @description WHERE `Skill Name` = @oldN;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", skillName);
                cmd.Parameters.AddWithValue("@description", skillDescription);
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

        public static void deleteSkill(string skillName)
        {

            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM bms_skills WHERE `SKill Name` = @name;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", skillName);
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
