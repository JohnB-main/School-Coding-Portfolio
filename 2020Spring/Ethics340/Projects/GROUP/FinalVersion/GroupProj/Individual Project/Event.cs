using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Exception = System.Exception;
using String = System.String;

namespace GroupProject
{

    class Event
    {
        String title;
        String startTime;
        String endTime;
        String reminder;
        String location;
        String date;
        String description;
        String owner;
        int eventID;


        public Event(String t, String st, String et, String r, String l, String d, String ow, String[] at, String ds)
        {
            title = t;
            startTime = st;
            endTime = et;
            reminder = r;
            location = l;
            date = d;
            owner = ow;
            description = ds;
        }

        public Event()
        {

        }


        public void saveEvent(List<String> attendees)
        {

            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //insertion into the event table
                string sql = "INSERT INTO gbmevent (title, date, starttime, endtime, reminder, description, location, owner) " +
                    "VALUES (@title, @date, @startTime, @endTime, @reminder, @description, @location, @owner)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@reminder", reminder);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@owner", owner);
                cmd.ExecuteNonQuery();

                //insertion loop into the attending event table for all attendees (ownerevent)
                for (int i = 0; i < attendees.Count; i++)
                {
                    sql = "INSERT INTO gbmownerevent VALUES(@attend, (SELECT DISTINCT LAST_INSERT_ID() FROM gbmevent))";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@attend", attendees[i]);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

        //check if there is a conflict/ avoid conflicts and select only times that are free as a choice
        public List<List<String>> GetTimes(List<String> involved, String date)
        {
            //lists for holding and walking variables
            List<List<String>> result = new List<List<string>>();
            List<String> starttimes = new List<string>();
            List<String> endtimes = new List<string>();
            String sversion;
            sversion = String.Join(", ", involved);
            if (sversion[0] == ',')
                sversion = sversion.Substring(1);
            //select statement to get the times of those involved
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            DataTable myTable = new DataTable();
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT  eventid, date, starttime, endtime FROM gbmevent WHERE date= @date AND eventid IN (SELECT event FROM gbmownerevent WHERE attendee IN(@check)) ORDER BY DATE, starttime";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@check", sversion);
                cmd.Parameters.AddWithValue("@date", date);
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
                Console.WriteLine("This is a start time" + row["starttime"].ToString());
                Console.WriteLine("This is an end time" + row["endtime"].ToString());

                starttimes.Add(row["starttime"].ToString());
                endtimes.Add(row["endtime"].ToString());
            }

            //add the two lists and return them            
            result.Add(starttimes);
            result.Add(endtimes);
            return result;
        }


        public void updateEventValue(String t, String st, String et, String r, String l, String d, String ow, String ds)
        {
            title = t;
            startTime = st;
            endTime = et;
            reminder = r;
            location = l;
            date = d;
            owner = ow;
            description = ds;
        }
        public String getStartTime()
        {
            return startTime;
        }

        public int getEventID()
        {
            return eventID
        }

        public String getEndTime()
        {
            return endTime;
        }

        public String getReminder()
        {
            return reminder;
        }

        public String getLocation()
        {
            return location;
        }
        public String getTitle()
        {
            return title;
        }

        public String getDescription()
        {
            return description;
        }

        public String getOwner()
        {
            return owner;
        }

        //method to get attendees from an event and not rooms
        public List<String> getAttendees()
        {
            List<String> attendees = new List<String>();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            DataTable myTable = new DataTable();
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT attendee FROM gbmownerevent WHERE attendee not LIKE 'LOC-%' AND attendee !=@owner AND event = @eid; ";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@eid", eventID);
                cmd.Parameters.AddWithValue("@owner", owner);
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
                attendees.Add(row["attendee"].ToString());
            }

            return attendees;
        }

        //gets event lists for that day ONLY for the current user
        public static ArrayList getEventList(string dateString, string username)
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date that correspond to user's username
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                //getting events with the user in them and matching it with the event table or to get monthly events

                string sql;
                if(dateString.Length==2)
                    sql= "SELECT* FROM gbmevent WHERE MONTH(DATE) = @myDate AND eventid IN(SELECT distinct event FROM gbmownerevent WHERE attendee = @user) ORDER BY DATE, starttime;";
                else
                    sql="SELECT * FROM gbmevent WHERE date =@mydate AND eventid IN (SELECT distinct event FROM gbmownerevent WHERE attendee = @user) ORDER BY DATE, starttime;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", dateString);
                cmd.Parameters.AddWithValue("@user", username);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.eventID = Int32.Parse(row["eventid"].ToString());
                newEvent.title = row["title"].ToString();
                newEvent.date = row["date"].ToString();
                newEvent.startTime = row["startTime"].ToString();
                newEvent.endTime = row["endTime"].ToString();
                newEvent.reminder = row["reminder"].ToString();
                newEvent.description = row["description"].ToString();
                newEvent.location = row["location"].ToString();
                newEvent.owner = row["owner"].ToString();
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }

        public void deleteEvent()
        {
            Console.WriteLine("ID of deleted event: " + this.eventID);


            string connStr = "server=csdatabase.eku.edu;user=stu_csc340;database=csc340_db;port=3306;password=Colonels18;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM gbmevent WHERE eventid = @eventID;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventID", this.eventID);
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
