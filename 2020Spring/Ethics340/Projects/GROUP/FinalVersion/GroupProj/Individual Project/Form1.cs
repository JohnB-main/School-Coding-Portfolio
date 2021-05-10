using java.util.concurrent;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GroupProject
{

    public partial class Form1 : Form
    {

        User curUser;
        Event newEvent;
        System.Collections.ArrayList eList;
        Event selectedEvent = null;
        List<String> key = new List<String>();
        List<List<String>> ranges = new List<List<string>>();
        public Form1()
        {
            InitializeComponent();
            curUser = new User();
            key.Add("00:00");
            key.Add("00:30");
            key.Add("01:00");
            key.Add("01:30");
            key.Add("02:00");
            key.Add("02:30");
            key.Add("03:00");
            key.Add("03:30");
            key.Add("04:00");
            key.Add("04:30");
            key.Add("05:00");
            key.Add("05:30");
            key.Add("06:00");
            key.Add("06:30");
            key.Add("07:00");
            key.Add("07:30");
            key.Add("08:00");
            key.Add("08:30");
            key.Add("09:00");
            key.Add("09:30");
            key.Add("10:00");
            key.Add("10:30");
            key.Add("11:00");
            key.Add("11:30");
            key.Add("12:00");
            key.Add("12:30");
            key.Add("13:00");
            key.Add("13:30");
            key.Add("14:00");
            key.Add("14:30");
            key.Add("15:00");
            key.Add("15:30");
            key.Add("16:00");
            key.Add("16:30");
            key.Add("17:00");
            key.Add("17:30");
            key.Add("18:00");
            key.Add("18:30");
            key.Add("19:00");
            key.Add("19:30");
            key.Add("20:00");
            key.Add("20:30");
            key.Add("21:00");
            key.Add("21:30");
            key.Add("22:00");
            key.Add("22:30");
            key.Add("23:00");
            key.Add("23:30");
            key.Add("24:00");
            button6.Visible = false;
            button7.Visible = false;
        }

        private void initializeAttendSelection(String eOwner)
        {
            checkedListBox1.Items.Clear();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            DataTable myTable = new DataTable();
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT distinct username FROM gbmuser WHERE username !=@owner AND username not LIKE 'LOC-%'; ";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@owner", eOwner);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            foreach (DataRow row in myTable.Rows)
            {
                checkedListBox1.Items.Add(row["username"].ToString());
            }
        }

        private void initializeLocationSelection()
        {
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            DataTable myTable = new DataTable();
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT username FROM gbmuser WHERE username LIKE 'LOC-%'; ";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            foreach (DataRow row in myTable.Rows)
            {
                comboBox3.Items.Add(row["username"].ToString());
            }
        }
        private int getValue(String time)
        {
            int pos;
            switch (time)
            {
                case "00:00":
                    pos = 0;
                    break;
                case "00:30":
                    pos = 1;
                    break;
                case "01:00":
                    pos = 2;
                    break;
                case "01:30":
                    pos = 3;
                    break;
                case "02:00":
                    pos = 4;
                    break;
                case "02:30":
                    pos = 5;
                    break;
                case "03:00":
                    pos = 6;
                    break;
                case "03:30":
                    pos = 7;
                    break;
                case "04:00":
                    pos = 8;
                    break;
                case "04:30":
                    pos = 9;
                    break;
                case "05:00":
                    pos = 10;
                    break;
                case "05:30":
                    pos = 11;
                    break;
                case "06:00":
                    pos = 12;
                    break;
                case "06:30":
                    pos = 13;
                    break;
                case "07:00":
                    pos = 14;
                    break;
                case "07:30":
                    pos = 15;
                    break;
                case "08:00":
                    pos = 16;
                    break;
                case "08:30":
                    pos = 17;
                    break;
                case "09:00":
                    pos = 18;
                    break;
                case "09:30":
                    pos = 19;
                    break;
                case "10:00":
                    pos = 20;
                    break;
                case "10:30":
                    pos = 21;
                    break;
                case "11:00":
                    pos = 22;
                    break;
                case "11:30":
                    pos = 23;
                    break;
                case "12:00":
                    pos = 24;
                    break;
                case "12:30":
                    pos = 25;
                    break;
                case "13:00":
                    pos = 26;
                    break;
                case "13:30":
                    pos = 27;
                    break;
                case "14:00":
                    pos = 28;
                    break;
                case "14:30":
                    pos = 29;
                    break;
                case "15:00":
                    pos = 30;
                    break;
                case "15:30":
                    pos = 31;
                    break;
                case "16:00":
                    pos = 32;
                    break;
                case "16:30":
                    pos = 33;
                    break;
                case "17:00":
                    pos = 34;
                    break;
                case "17:30":
                    pos = 35;
                    break;
                case "18:00":
                    pos = 36;
                    break;
                case "18:30":
                    pos = 37;
                    break;
                case "19:00":
                    pos = 38;
                    break;
                case "19:30":
                    pos = 39;
                    break;
                case "20:00":
                    pos = 41;
                    break;
                case "20:30":
                    pos = 42;
                    break;
                case "21:00":
                    pos = 43;
                    break;
                case "21:30":
                    pos = 44;
                    break;
                case "22:00":
                    pos = 45;
                    break;
                case "22:30":
                    pos = 46;
                    break;
                case "23:00":
                    pos = 47;
                    break;
                case "23:30":
                    pos = 48;
                    break;
                case "24:00":
                    pos = 49;
                    break;
                default:
                    pos = -1; ;
                    break;
            }
            return pos;

        }

        private List<String> getRange(int s, int e)
        {
            Console.WriteLine("int s" + s + " int e" + e);
            List<String> timeValues = new List<string>();
            for (; s < e; s++)
            {
                timeValues.Add(key[s]);
            }
            return timeValues;
        }

        //add event button
        private void Button1_Click(object sender, EventArgs e)
        {
            initializeAttendSelection(curUser.username);
            button1.BackColor = Color.Red;
            emptyEventForm();
            textBox8.Text = curUser.username;

            textBox2.Visible = false;
            textBox3.Visible = false;
            checkedListBox1.Enabled=true;
            comboBox3.Enabled = true;
            button6.Visible = true;
            button7.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        //search for times action button
        private void Button6_Click(object sender, EventArgs e)
        {
            ranges.Clear();
            listBox3.Items.Clear();
            listBox2.Items.Clear();
            List<String> startTimes = new List<string>();
            List<String> endTimes = new List<string>();

            if (textBox1.Text.Length == 0)
            {
                string message = "Need a title for the new event.";
                string caption = "Missing Title";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            Event newEvent = new Event();

            List<List<String>> times = new List<List<string>>();
            List<String> allEvents = new List<string>();
            newEvent.updateEventValue(textBox1.Text, textBox2.Text, textBox3.Text,
               textBox4.Text, comboBox3.Text, thisDate, curUser.username, textBox7.Text);
            if (newEvent.getLocation() != "LOC-NA")
            {
                allEvents.Add(newEvent.getLocation());
            }
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                //Console.WriteLine(checkedListBox1.CheckedItems[i].ToString());
                Console.WriteLine("This is starts:" + allEvents.ToArray().ToString());
                allEvents.Add(checkedListBox1.CheckedItems[i].ToString());
            }
            allEvents.Add(curUser.username);
            times = newEvent.GetTimes(allEvents, thisDate);
            //waiting a moment since the database did not always want to cooperate with my internet
            TimeUnit.SECONDS.sleep(3);
            startTimes = times[0];
            endTimes = times[1];

            if (startTimes.Count == 0)
            {
                startTimes.Add("00:00");
                endTimes.Add("24:00");
            }
            if (startTimes[0] != "00:00")
            {
                ranges.Add(getRange(0, getValue(startTimes[0])));
            }
            for (int loop = 0; loop < startTimes.Count; loop++)
            {
                ranges.Add(getRange(getValue(startTimes[loop]), getValue(endTimes[loop])));
            }
            if (endTimes[endTimes.Count - 1] != "24:00")
            {
                ranges.Add(getRange(getValue(endTimes[endTimes.Count - 1]), 49));
            }
            panel3.Visible = true;
            panel3.BringToFront();
            for (int i = 0; i < ranges.Count; i++)
            {
                for (int j = 0; j < ranges[i].Count; j++)
                {
                    listBox2.Items.Add(ranges[i][j]);
                }
            }




            /*{
                string message = "The new event has time conflict with some existing event.";
                string caption = "Error Detected in Time Specification";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }*/






            Console.WriteLine("Conflict Resolved");
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //private void ListBox1_SelectedIndexChanged()
        {
            if (listBox1.SelectedIndex == -1)
                listBox1.SelectedIndex = 0;
            Event currentEvent = (Event)eList[listBox1.SelectedIndex];

            selectedEvent = currentEvent;

            panel1.Visible = true;
            initializeAttendSelection(currentEvent.getOwner());
            textBox1.Text = currentEvent.getTitle();
            textBox2.Text = currentEvent.getStartTime();
            textBox3.Text = currentEvent.getEndTime();
            textBox4.Text = currentEvent.getReminder();
            comboBox3.Text = currentEvent.getLocation();
            textBox7.Text = currentEvent.getDescription();
            textBox8.Text = currentEvent.getOwner();
            List<String> attending = currentEvent.getAttendees();
            foreach (String item in attending)
            {
                if (checkedListBox1.Items.Contains(item))
                {
                    checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(item), true);
                }
            }
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            label1.Text = "Events on " + thisDate;
            eList = Event.getEventList(thisDate, curUser.username);
            button6.Visible = false;
            button7.Visible = false;
            listBox1.Items.Clear();
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);
            }
            if (eList.Count == 0)
                selectedEvent = null;
            else
                selectedEvent = (Event)eList[0];
        }

        private void emptyEventForm()
        {
            panel1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox3.Text = "";
            textBox7.Text = "";
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button1.BackColor = DefaultBackColor;
            button6.Visible = false;
            button7.Visible = false;
            textBox2.Visible = true;
            //comboBox1.Visible = false;
            textBox3.Visible = true;
            //comboBox2.Visible = false;
            if (eList.Count != 0)
            {
                ListBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                emptyEventForm();
            }
        }

        //delete button
        private void Button2_Click(object sender, EventArgs e)
        {

            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null)
            {
                message = "There is no event selected.";
                caption = "Error: No event been seletced";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                if (selectedEvent.getOwner() != curUser.username) //no the owner of event = no delete event
                {
                    message = "You do not have permission to delete this event, contact the owner.";
                    caption = "Delete Failed";
                    buttons = MessageBoxButtons.OK;
                    DialogResult result;
                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                }
                else
                {

                    button2.BackColor = Color.Red;
                    message = "Do you really want to delete this event?";
                    caption = "Delete Event";
                    buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    //delete event
                    if (result == System.Windows.Forms.DialogResult.Yes)

                    {
                        String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                        selectedEvent.deleteEvent();
                        Button7_Click(sender, e);
                        //String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                        label1.Text = "Events on " + thisDate;
                        eList = Event.getEventList(thisDate, curUser.username);
                        button6.Visible = false;
                        button7.Visible = false;
                        listBox1.Items.Clear();
                        for (int i = 0; i < eList.Count; i++)
                        {
                            Event currentEvent = (Event)eList[i];
                            String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                            listBox1.Items.Add(aString);
                        }
                    }
                    button2.BackColor = DefaultBackColor;
                    emptyEventForm();
                    
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DateTime thisDay = DateTime.Today;
            String dateString = thisDay.ToString("MM", System.Globalization.CultureInfo.InvariantCulture);
            
            label1.Text = "Monthly Events of " + dateString;
            eList = Event.getEventList(dateString, curUser.username);

            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent.getOwner() != curUser.username) //no the owner of event = no editing event
            {
                message = "You do not have permission to edit this event, contact the owner.";
                caption = "Edit Failed";
                buttons = MessageBoxButtons.OK;
                DialogResult result;
                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
            }
            else
                
                button4.BackColor=Color.LawnGreen;
                button10.Visible = true;
                button11.Visible = true;
                button10.BringToFront();
                button11.BringToFront();

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


        // The login button and authorization
        private void button3_Click_1(object sender, EventArgs e)
        {
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            String logU = textBox10.Text.ToString();
            String logP = textBox11.Text.ToString();
            int res = 1;
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT count(*) FROM gbmuser WHERE username = @user AND password = @pass; ";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", logU);
                cmd.Parameters.AddWithValue("@pass", logP);

                res = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            if (res == 1)
            {
                curUser.username = logU;
                initializeLocationSelection();
                panel2.Visible = false;
                
                DateTime thisDay = DateTime.Today;
                String dateString = thisDay.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                label1.Text = "Events on " + dateString;
                eList = Event.getEventList(dateString, curUser.username);

                for (int i = 0; i < eList.Count; i++)
                {
                    Event currentEvent = (Event)eList[i];
                    String aString = currentEvent.getStartTime() + "  " + currentEvent.getTitle();
                    listBox1.Items.Add(aString);
                }
            }
            else
            {
                string message = "Username or Password Incorrect.";
                string caption = "Login Failed";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        //Confrim timings and save
        private void button8_Click(object sender, EventArgs e)
        {
            String eventStartTime = listBox2.Text;
            String eventEndTime = listBox3.Text;
            panel3.Visible = false;
            panel3.SendToBack();
            //Event tobesaved = new Event();
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");


            newEvent.updateEventValue(textBox1.Text, eventStartTime, eventEndTime,
                textBox4.Text, comboBox3.Text, thisDate, curUser.username, textBox7.Text);



            //saving the event to the database
            List<String> attendees = new List<String>();
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                //Console.WriteLine(checkedListBox1.CheckedItems[i].ToString());
                attendees.Add(checkedListBox1.CheckedItems[i].ToString());
            }



            newEvent.saveEvent(attendees);// needed for keeping up with new insertion
            string message = "The new event has been saved to database successfully.";
            string caption = "New Event Been Saved";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
            Button7_Click(sender, e);
            thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            label1.Text = "Events on " + thisDate;
            eList = Event.getEventList(thisDate, curUser.username);
            button6.Visible = false;
            button7.Visible = false;
            checkedListBox1.Enabled = false;
            comboBox3.Enabled = false;
            listBox1.Items.Clear();
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);

            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            //prepping to only show the available times in the ending times box            
            String find = listBox2.SelectedItem.ToString();
            int i, j = 0;
        
            for (i = 0; i < ranges.Count; i++)
            {
                for (j = 0; j < ranges[i].Count; j++)
                {
                    if (ranges[i][j] == find)
                        break;
                }
                if (ranges[i][j] == find)
                    break;
            }
            int start = j + 1;
            int end = ranges[i].Count;
            for (; start < end; start++)
            {
                listBox3.Items.Add(ranges[i][start]);
            }
        }

        //submit editing changes
        private void button10_Click(object sender, EventArgs e)
        {
            String ntitle = textBox1.Text;
            String nreminder=textBox4.Text;
            String ndescription = textBox7.Text;
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            int changeE = selectedEvent.getEventID();            
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = " UPDATE gbmevent SET title = @title, reminder = @rem, description =@desc WHERE eventid =@cevent; ";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", ntitle);                 
                cmd.Parameters.AddWithValue("@rem", nreminder);
                cmd.Parameters.AddWithValue("@desc", ndescription);                
                cmd.Parameters.AddWithValue("@cevent", changeE);
                cmd.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
            //return to before
            button4.BackColor = DefaultBackColor;
            button10.Visible = false;
            button11.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //return to before
            button4.BackColor = DefaultBackColor;
            button10.Visible = false;
            button11.Visible = false;
        }
    }
}
