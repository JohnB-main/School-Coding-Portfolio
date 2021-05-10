using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _313ProjectFinal
{
    public partial class search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*Method for taking care of name searching*/
        protected void name_Click(object sender, EventArgs e)
        {
            /*connection*/
            string connStr = "server=localhost;user=root;database=bl3weapons;port=3306;password='';";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                //write our SQL statement as a String
                //sort by element, since that is a differing thing between the same gun name
                string sql = "select name as 'Name', type as 'Type', ele as 'Element', pre as 'Prefix(s)', alien as 'Alien Barrel' from weapons where name = @nm order by ele;";

                //create a SQL command object
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //add values to our placeholders
                cmd.Parameters.AddWithValue("@nm", name.Text);

                //attach the output of our SQL command to the GridView
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                //reset text box           
                name.Text = string.Empty;

            }
            //handle errors for possible issues
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            //close our database connection
            conn.Close();
        }

        //filter by type of weapon
        protected void type_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=bl3weapons;port=3306;password='';";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                //write our SQL statement as a String
                //order by name for more organization
                string sql = "select name as 'Name', type as 'Type', ele as 'Element', pre as 'Prefix(s)', alien as 'Alien Barrel' from weapons where type = @ty order by name;";

                //create a SQL command object
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //add values to our placeholders
                cmd.Parameters.AddWithValue("@ty", type.Text);

                //attach the output of our SQL command to the GridView
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                //reset select value         
                type.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            //close our database connection
            conn.Close();
        }


        //filter by element
        protected void ele_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=bl3weapons;port=3306;password='';";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                //write our SQL statement as a String
                //order by name to give more organization
                string sql = "select name as 'Name', type as 'Type', ele as 'Element', pre as 'Prefix(s)', alien as 'Alien Barrel' from weapons where ele = @el order by name;";

                //create a SQL command object
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //add values to our placeholders
                cmd.Parameters.AddWithValue("@el", ele.Text);

                //attach the output of our SQL command to the GridView
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                //reset text drop boxes          
                ele.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            //close our database connection
            conn.Close();
        }


        //filter by alien
        protected void al_Click(object sender, EventArgs e)
        {
            string connStr = "server=localhost;user=root;database=bl3weapons;port=3306;password='';";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                //write our SQL statement as a String
                //order by name for organization
                string sql = "select name as 'Name', type as 'Type', ele as 'Element', pre as 'Prefix(s)', alien as 'Alien Barrel' from weapons where alien = @al order by name;";

                //create a SQL command object
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                //add values to our placeholders
                cmd.Parameters.AddWithValue("@al", alien.Text);

                //attach the output of our SQL command to the GridView
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();

                //reset text boxes           
                ele.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }

            //close our database connection
            conn.Close();
        }
    }
}