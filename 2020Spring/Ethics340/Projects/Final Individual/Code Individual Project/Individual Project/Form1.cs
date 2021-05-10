using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Individual_Project
{
    public partial class Form1 : Form
    {
        ArrayList eList;
        Event selectedEvent = null;        
        public Form1()
        {
            InitializeComponent();
            DateTime thisDay = DateTime.Today;
            String dateString = thisDay.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            //dateString = dateString.Substring(0, 4) + "-" + dateString.Substring(4, 2) + "-" + dateString.Substring(6);
            //Console.Out.WriteLine("dateString: " + dateString);
            label1.Text = "Events on " + dateString;
            eList = Event.getEventList(dateString);
            button6.Visible = false;
            button7.Visible = false;
            //ListBox1_SelectedIndexChanged();
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);
            }
            initializeTimeSections();
        }

        private void initializeTimeSections()
        {
            //textBox2.Visible = false;
            comboBox1.Items.Add("00:00");
            comboBox1.Items.Add("00:30");
            comboBox1.Items.Add("01:00");
            comboBox1.Items.Add("01:30");
            comboBox1.Items.Add("02:00");
            comboBox1.Items.Add("02:30");
            comboBox1.Items.Add("03:00");
            comboBox1.Items.Add("03:30");
            comboBox1.Items.Add("04:00");
            comboBox1.Items.Add("04:30");
            comboBox1.Items.Add("05:00");
            comboBox1.Items.Add("05:30");
            comboBox1.Items.Add("06:00");
            comboBox1.Items.Add("06:30");
            comboBox1.Items.Add("07:00");
            comboBox1.Items.Add("07:30");
            comboBox1.Items.Add("08:00");
            comboBox1.Items.Add("08:30");
            comboBox1.Items.Add("09:00");
            comboBox1.Items.Add("09:30");
            comboBox1.Items.Add("10:00");
            comboBox1.Items.Add("10:30");
            comboBox1.Items.Add("11:00");
            comboBox1.Items.Add("11:30");
            comboBox1.Items.Add("12:00");
            comboBox1.Items.Add("12:30");
            comboBox1.Items.Add("13:00");
            comboBox1.Items.Add("13:30");
            comboBox1.Items.Add("14:00");
            comboBox1.Items.Add("14:30");
            comboBox1.Items.Add("15:00");
            comboBox1.Items.Add("15:30");
            comboBox1.Items.Add("16:00");
            comboBox1.Items.Add("16:30");
            comboBox1.Items.Add("17:00");
            comboBox1.Items.Add("17:30");
            comboBox1.Items.Add("18:00");
            comboBox1.Items.Add("18:30");
            comboBox1.Items.Add("19:00");
            comboBox1.Items.Add("19:30");
            comboBox1.Items.Add("20:00");
            comboBox1.Items.Add("20:30");
            comboBox1.Items.Add("21:00");
            comboBox1.Items.Add("21:30");
            comboBox1.Items.Add("22:00");
            comboBox1.Items.Add("22:30");
            comboBox1.Items.Add("23:00");
            comboBox1.Items.Add("23:30");
            comboBox1.Items.Add("24:00");

            comboBox2.Items.Add("00:00");
            comboBox2.Items.Add("00:30");
            comboBox2.Items.Add("01:00");
            comboBox2.Items.Add("01:30");
            comboBox2.Items.Add("02:00");
            comboBox2.Items.Add("02:30");
            comboBox2.Items.Add("03:00");
            comboBox2.Items.Add("03:30");
            comboBox2.Items.Add("04:00");
            comboBox2.Items.Add("04:30");
            comboBox2.Items.Add("05:00");
            comboBox2.Items.Add("05:30");
            comboBox2.Items.Add("06:00");
            comboBox2.Items.Add("06:30");
            comboBox2.Items.Add("07:00");
            comboBox2.Items.Add("07:30");
            comboBox2.Items.Add("08:00");
            comboBox2.Items.Add("08:30");
            comboBox2.Items.Add("09:00");
            comboBox2.Items.Add("09:30");
            comboBox2.Items.Add("10:00");
            comboBox2.Items.Add("10:30");
            comboBox2.Items.Add("11:00");
            comboBox2.Items.Add("11:30");
            comboBox2.Items.Add("12:00");
            comboBox2.Items.Add("12:30");
            comboBox2.Items.Add("13:00");
            comboBox2.Items.Add("13:30");
            comboBox2.Items.Add("14:00");
            comboBox2.Items.Add("14:30");
            comboBox2.Items.Add("15:00");
            comboBox2.Items.Add("15:30");
            comboBox2.Items.Add("16:00");
            comboBox2.Items.Add("16:30");
            comboBox2.Items.Add("17:00");
            comboBox2.Items.Add("17:30");
            comboBox2.Items.Add("18:00");
            comboBox2.Items.Add("18:30");
            comboBox2.Items.Add("19:00");
            comboBox2.Items.Add("19:30");
            comboBox2.Items.Add("20:00");
            comboBox2.Items.Add("20:30");
            comboBox2.Items.Add("21:00");
            comboBox2.Items.Add("21:30");
            comboBox2.Items.Add("22:00");
            comboBox2.Items.Add("22:30");
            comboBox2.Items.Add("23:00");
            comboBox2.Items.Add("23:30");
            comboBox2.Items.Add("24:00");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
            /*
            panel1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            */
            emptyEventForm();
            textBox2.Visible = false;
            comboBox1.Visible = true;
            comboBox1.SelectedIndex = 0;
            textBox3.Visible = false;
            comboBox2.Visible = true;
            comboBox2.SelectedIndex = 0;
            button6.Visible = true;
            button7.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;            
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
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

            newEvent.updateEventValue(textBox1.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(),
               textBox4.Text, textBox5.Text, thisDate, textBox7.Text);
            bool noConflict = newEvent.checkConflict(eList);
            if (noConflict == false)
            {
                string message = "The new event has time conflict with some existing event.";
                string caption = "Error Detected in Time Specification";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {                
                newEvent.saveEvent();                
                string message = "The new event has been saved to database successfully.";
                string caption = "New Event Beennn Saved";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                Button7_Click(sender, e);
                thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                label1.Text = "Events on " + thisDate;
                eList = Event.getEventList(thisDate);
                button6.Visible = false;
                button7.Visible = false;
                listBox1.Items.Clear();
                panel1.Visible = false;
                for (int i = 0; i < eList.Count; i++)
                {
                    Event currentEvent = (Event)eList[i];
                    String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                    listBox1.Items.Add(aString);
                }
            }
            Console.WriteLine("Conflict = " + noConflict);
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)        
        {
            if (listBox1.SelectedIndex == -1)
                listBox1.SelectedIndex = 0;
            Event currentEvent = (Event)eList[listBox1.SelectedIndex];

            selectedEvent = currentEvent;

            panel1.Visible = true;
            textBox1.Text = currentEvent.getTitle();
            textBox2.Text = currentEvent.getStartTime();
            textBox3.Text = currentEvent.getEndTime();
            textBox4.Text = currentEvent.getReminder();
            textBox5.Text = currentEvent.getLocation();
            textBox7.Text = currentEvent.getDescription();
        }

        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            Button7_Click(sender, e);
            //String thisDate = monthCalendar1.SelectionRange.Start.ToShortDateString();
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            label1.Text = "Events on " + thisDate;
            //label1.BackColor = Color.Yellow;
            eList = Event.getEventList(thisDate);
            button6.Visible = false;
            button7.Visible = false;
            //ListBox1_SelectedIndexChanged();
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
                selectedEvent = (Event) eList[0];
        }

        private void emptyEventForm()
        {
            panel1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";            
            textBox7.Text = "";
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;            
            button4.Enabled = true;
            button5.Enabled = true;
            button1.BackColor = DefaultBackColor;
            button6.Visible = false;
            button7.Visible = false;
            textBox2.Visible = true;
            comboBox1.Visible = true;
            textBox3.Visible = true;
            comboBox2.Visible = true;
            if (eList.Count != 0)
            {
                ListBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                emptyEventForm();
            }
            panel1.Visible = false;
        }

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
                button2.BackColor = Color.Red;
                message = "Do you really want to delete this event?";
                caption = "Delete Event";
                buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    
                    String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    selectedEvent.deleteEvent();
                    Button7_Click(sender, e);
                    //String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                    label1.Text = "Events on " + thisDate;
                    eList = Event.getEventList(thisDate);
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
                selectedEvent = null;
                button2.BackColor = DefaultBackColor;
            }
            
        }

        //get monthly list and display
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("MM");
            label1.Text = "Monthly Events In " + thisDate;
            //label1.BackColor = Color.Yellow;
            eList = Event.getEventList(thisDate);
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

        private void button4_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            MessageBoxButtons buttons;

            if (textBox1.Text.Length == 0)
            {
                message = "Need a title for the new event.";
                caption = "Missing Title";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            if (selectedEvent == null)
            {
                message = "There is no event selected.";
                caption = "Error: No event been seletced";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }

            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            Event newEvent = new Event();

            newEvent.updateEventValue(textBox1.Text, comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(),
               textBox4.Text, textBox5.Text, thisDate, textBox7.Text);
            bool noConflict = newEvent.checkConflict(eList);
            if (noConflict == false)
            {
                 message = "The new event has time conflict with some existing event.";
                 caption = "Error Detected in Time Specification";
                 buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            else
            {                                
                newEvent.editEvent(selectedEvent.getEventID());                
                 message = "The event has been editted and updated to database successfully.";
                 caption = "New Event Beennn Saved";
                 buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                Button7_Click(sender, e);
                thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                label1.Text = "Events on " + thisDate;
                eList = Event.getEventList(thisDate);
                button6.Visible = false;
                button7.Visible = false;
                listBox1.Items.Clear();
                panel1.Visible = false;
                for (int i = 0; i < eList.Count; i++)
                {
                    Event currentEvent = (Event)eList[i];
                    String aString = currentEvent.getStartTime() + "  " + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                    listBox1.Items.Add(aString);
                }
            }
        }
    }
}
