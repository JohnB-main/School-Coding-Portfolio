using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _313ProjectFinal
{
    public partial class submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string connStr = "server=localhost;user=root;database=bl3weapons;port=3306;password='';";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                //I'm doing this for testing                
                conn.Open();

                //write our SQL statement as a String
                string sql = "insert  into `weapons`(`name`,`type`,`ele`,`pre`, `alien`)" +
                    "VALUES(@nm, @ty, @ele, @pre, @al);";

                //create a SQL command object
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //add values to our placeholders
                cmd.Parameters.AddWithValue("@nm", name.Text);
                cmd.Parameters.AddWithValue("@ty", type.Text);
                cmd.Parameters.AddWithValue("@ele", ele.Text);
                cmd.Parameters.AddWithValue("@pre", pre.Text);
                cmd.Parameters.AddWithValue("@al", alien.Text);

                //execute our sql command
                cmd.ExecuteNonQuery();

                

                //reset text boxes and lists
                name.Text = string.Empty;
                type.SelectedIndex = 0;
                ele.SelectedIndex = 5;
                pre.Text = string.Empty;
                alien.SelectedIndex = 2;

                //change status at bottom of page for viewer update/feedback
                status.Text="Submission Accepted";


            }//handle errors
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            //close our database connection
            conn.Close();


        }
    }
}