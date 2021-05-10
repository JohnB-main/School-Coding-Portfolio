using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CareActerVS
{
    class Character
    {
        // Define class vars
        String charName;
        String race;
        String cClass;
        int level;
        String alignment;
        String background;
        // Attributes
        int str;
        int dex;
        int con;
        int iint;
        int wis;
        int cha;
        int AC;
        int speed;
        int maxHP;


        public Character()
        {

        }

        // building constuctor
        public Character(String n, String r, String c, int l, String a, String b, int st, int de, int co, int iin, int wi, int ch, int armorC, int sp, int mhp)
        {
            charName = n;
            race = r;
            cClass = c;
            level = l;
            alignment = a;
            background = b;
            str = st;
            dex = de;
            con = co;
            iint = iin;
            wis = wi;
            cha = ch;
            AC = armorC;
            speed = sp;
            maxHP = mhp;
        }

        //function to get all char names
        public static String[] getCharNames()
        {
            String[] charNames = { };

            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT `Character Name` FROM bms_character_main";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

            //get data from collumn and make an array, then save
            charNames = myTable.AsEnumerable().Select(r => r.Field<string>("Character Name")).ToArray();

            return charNames;
        }
        

        //function to save an approved new character
        public void addCharacter()
        {
            //prepare an SQL query to retrieve all the events on the same, specified date            
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);           
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO bms_character_main VALUES (@name, @race, @class, @level, @align, @backg);";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", charName);
                cmd.Parameters.AddWithValue("@race", race);
                cmd.Parameters.AddWithValue("@class", cClass);
                cmd.Parameters.AddWithValue("@level", level);
                cmd.Parameters.AddWithValue("@align", alignment);
                cmd.Parameters.AddWithValue("@backg", background);                
                cmd.ExecuteNonQuery();
                
                sql = "INSERT INTO bms_attributes VALUES (@name, @str, @dex, @con, @int, @wis, @cha, @ac, @spd, @maxhp);";
                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("@name", charName);
                cmd2.Parameters.AddWithValue("@str", str);
                cmd2.Parameters.AddWithValue("@dex", dex);
                cmd2.Parameters.AddWithValue("@con", con);
                cmd2.Parameters.AddWithValue("@int", iint);
                cmd2.Parameters.AddWithValue("@wis", wis);
                cmd2.Parameters.AddWithValue("@cha", cha);
                cmd2.Parameters.AddWithValue("@ac", AC);
                cmd2.Parameters.AddWithValue("@spd", speed);
                cmd2.Parameters.AddWithValue("@maxhp", maxHP);                
                cmd2.ExecuteNonQuery();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done. Adding Character");
        }


        public void editCharacter(String oldName)
        {
            //prepare an SQL query to retrieve all the events on the same, specified date            
            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE bms_character_main "+
                    "SET `Character Name` = @name,  `Race` = @race,  `Class` = @class,  `Level` = @level,  `Alignment` = @align,  `background` = @backg " +
                    "WHERE `character name` = @oldN; ";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", charName);
                cmd.Parameters.AddWithValue("@race", race);
                cmd.Parameters.AddWithValue("@class", cClass);
                cmd.Parameters.AddWithValue("@level", level);
                cmd.Parameters.AddWithValue("@align", alignment);
                cmd.Parameters.AddWithValue("@backg", background);
                cmd.Parameters.AddWithValue("@oldN", oldName);
                cmd.ExecuteNonQuery();

                //database has auto updated the name, so use the new name now as reference
                sql = "UPDATE bms_attributes SET  `Strength` =  @str, " +
                    " `Dexterity` = @dex,  `Constitution` = @con,  `Intelligence` = @int,  `Wisdom` = @wis,  `Charisma` = @cha,  `Armor Class` = @ac,  `Speed` = @spd,  `Max HP` = @maxhp" +
                    " where `character name` = @name;";
                MySql.Data.MySqlClient.MySqlCommand cmd2 = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd2.Parameters.AddWithValue("@name", charName);
                cmd2.Parameters.AddWithValue("@str", str);
                cmd2.Parameters.AddWithValue("@dex", dex);
                cmd2.Parameters.AddWithValue("@con", con);
                cmd2.Parameters.AddWithValue("@int", iint);
                cmd2.Parameters.AddWithValue("@wis", wis);
                cmd2.Parameters.AddWithValue("@cha", cha);
                cmd2.Parameters.AddWithValue("@ac", AC);
                cmd2.Parameters.AddWithValue("@spd", speed);
                cmd2.Parameters.AddWithValue("@maxhp", maxHP);                
                cmd2.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done. Editing Character");
        }


        public static void delCharacter(String cName)
        {

            string connStr = "server=157.89.28.130;user=ChangK;database=csc440;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL For Deletion...");
                conn.Open();
                string sql = "DELETE FROM bms_character_main WHERE `Character Name`= @name;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", cName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Delte Finished.");

        }
    }

    
}
