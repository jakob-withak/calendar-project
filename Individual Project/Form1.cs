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
        //used in various functions
        ArrayList eList;
        Event selectedEvent = null;
        int eventID;
        public Form1()
        {
            //This is the code neccessary for the system to start in the idle position.
            InitializeComponent();
            DateTime thisDay = DateTime.Today;
            String dateString = thisDay.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            label1.Text = "Events on " + dateString;
            eList = Event.getEventList(dateString);
            button6.Visible = false;
            button7.Visible = false;
            button3.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            listBox2.Items.Add("Welcome back, User");
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "-" + currentEvent.getEndTime()+ " " + currentEvent.getTitle();
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
        //add event button
        private void Button1_Click(object sender, EventArgs e)
        {
            button8.BackColor = DefaultBackColor;
            button1.BackColor = Color.Aqua;
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
        //save event
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
                string caption = "Error: Time Specification";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                newEvent.saveEvent();
                string message = "The new event has been saved to database successfully.";
                string caption = "New Event Saved";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                Button7_Click(sender, e);
                thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                label1.Text = "Events on " + thisDate;
                eList = Event.getEventList(thisDate);
                button6.Visible = false;
                button7.Visible = false;
                listBox1.Items.Clear();
                for (int i = 0; i < eList.Count; i++)
                {
                    Event currentEvent = (Event)eList[i];
                    String aString = currentEvent.getStartTime() + "-" + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                    listBox1.Items.Add(aString);
                }
            }
            panel1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button1.BackColor = DefaultBackColor;
            Console.WriteLine("Conflict = " + noConflict);
        }
        //make sure the correct event is selected. If there's not one, assign index to 0 to prevent an unhandled error.
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)

        {
            button8.BackColor = DefaultBackColor;
            if (listBox1.SelectedIndex == -1)
                listBox1.SelectedIndex = 0;
            Event currentEvent = (Event)eList[listBox1.SelectedIndex];

            selectedEvent = currentEvent;
            panel1.Visible = false;

            

        }
        //displays appropriate events on selected day
        private void MonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            panel1.Visible = false;
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            label1.Text = "Events on " + thisDate;
            eList = Event.getEventList(thisDate);
            button6.Visible = false;
            button7.Visible = false;
            listBox1.Items.Clear();
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getStartTime() + "-" + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                listBox1.Items.Add(aString);
            }
            if (eList.Count == 0)
                selectedEvent = null;
            else
                selectedEvent = (Event) eList[0];
        }
        //empty out input boxes for new event.
        private void emptyEventForm()
        {
            panel1.Visible = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        //cancel button
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
            comboBox1.Visible = false;
            textBox3.Visible = true;
            comboBox2.Visible = false;
            if (eList.Count != 0)
            {
                ListBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                emptyEventForm();
            }
        }
        //delete event
        private void Button2_Click(object sender, EventArgs e)
        {
            button8.BackColor = DefaultBackColor;
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null)
            {
                message = "There is no event selected.";
                caption = "Error: No event selected";
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
                    Console.WriteLine(selectedEvent.getEventID());
                    selectedEvent.deleteEvent();
                    message = "Event successfully deleted";
                    caption = "Removed";
                    buttons = MessageBoxButtons.OK;
                    result = MessageBox.Show(message, caption, buttons);
                    Button7_Click(sender, e);
                    label1.Text = "Events on " + thisDate;
                    eList = Event.getEventList(thisDate);
                    button6.Visible = false;
                    button7.Visible = false;
                    listBox1.Items.Clear();
                    for (int i = 0; i < eList.Count; i++)
                    {
                        Event currentEvent = (Event)eList[i];
                        String aString = currentEvent.getStartTime() + "-" + currentEvent.getEndTime() + "  " + currentEvent.getTitle();
                        listBox1.Items.Add(aString);
                    }
                }
                button2.BackColor = DefaultBackColor;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //view monthly event
        private void button5_Click(object sender, EventArgs e)
        {
            button8.BackColor = DefaultBackColor;
            button5.BackColor = Color.Crimson;
            panel1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button4.Visible = false;
            button5.Enabled = false;
            button8.Visible = false;
            //updates label for listbox
            String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            String mYear = thisDate.Substring(0,7);
            label1.Visible = false;
            label9.Text = "Events for the month of " + mYear;
            label9.Visible = true;

            //fetch all events for the month selected
            eList = Event.getEventListMonth(mYear);
            listBox3.Items.Clear();
            if (eList.Count == 0)
            {
                listBox3.Items.Add("No events for this month.");
            }
            for (int i = 0; i < eList.Count; i++)
            {
                Event currentEvent = (Event)eList[i];
                String aString = currentEvent.getDate().Substring(0,9) + " " + currentEvent.getTitle() + ":  " + currentEvent.getStartTime();
                listBox3.Items.Add(aString);
            }
            listBox3.Visible = true;
            button3.Visible = true;

        }

        //save changes button
        private void button9_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null)
            {
                message = "There is no event selected.";
                caption = "Error: No event selected";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                Event newEvent = new Event();
                String thisDate = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
                newEvent.updateEventValue(textBox1.Text, textBox2.Text, textBox3.Text,
                textBox4.Text, textBox5.Text, thisDate, textBox7.Text);
                Console.WriteLine("event id is" + eventID.ToString());
                eList = Event.getModifiedList(eventID, thisDate);
                bool noConflict = newEvent.checkConflict(eList);
                if (noConflict == false)
                {
                    message = "The updated event has a time conflict with some existing event.";
                    caption = "Error: Time Specification";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                }
                else
                {
                    
                    newEvent.updateEvent(eventID);
                    message = "Event has successfully been updated.";
                    caption = "Updated";
                    buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons);
                    listBox1.Items.Clear();
                    eList = Event.getEventList(thisDate);
                    for (int i = 0; i < eList.Count; i++)
                    {
                        Event currentEvent = (Event)eList[i];
                        String aString = currentEvent.getStartTime() + "-" + currentEvent.getEndTime()+" " + currentEvent.getTitle();
                        listBox1.Items.Add(aString);
                    }
                }

            }
            button1.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
            button8.Enabled = true;
            button4.BackColor = DefaultBackColor;
            button9.Visible = false;
            button10.Visible = false;
            panel1.Visible = false;
        }
        //done button
        private void button3_Click(object sender, EventArgs e)
        {
            button5.BackColor = DefaultBackColor;
            label9.Visible = false;
            listBox3.Visible = false;
            button3.Visible = false;
            label1.Visible = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Visible = true;
            button5.Enabled = true;
            button8.Visible = true;
        }
        //view event
        private void button8_Click(object sender, EventArgs e)
        {
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null || listBox1.SelectedIndex == -1)
            {
                message = "There is no event selected.";
                caption = "Error: No event selected";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
            }
            else
            {
                
                button8.BackColor = Color.Aqua;
                Event currentEvent = (Event)eList[listBox1.SelectedIndex];
                selectedEvent = currentEvent;
                panel1.Visible = true;
                textBox1.Text = currentEvent.getTitle();
                textBox2.Text = currentEvent.getStartTime();
                textBox3.Text = currentEvent.getEndTime();
                textBox4.Text = currentEvent.getReminder();
                textBox5.Text = currentEvent.getLocation();
                textBox7.Text = currentEvent.getDescription();
                eventID = currentEvent.getEventID();
            }
            //Console.WriteLine("Event ID is " + eventID.ToString());
        }
        //edit event button
        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Yellow;
            string message;
            string caption;
            MessageBoxButtons buttons;
            if (selectedEvent == null || listBox1.SelectedIndex == -1)
            {
                message = "There is no event selected.";
                caption = "Error: No event selected";
                buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                button4.BackColor = DefaultBackColor;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button5.Enabled = false;
                button8.Enabled = false;
                button9.Visible = true;
                button10.Visible = true;

                Event currentEvent = (Event)eList[listBox1.SelectedIndex];
                selectedEvent = currentEvent;
                panel1.Visible = true;
                textBox1.Text = currentEvent.getTitle();
                textBox2.Text = currentEvent.getStartTime();
                textBox3.Text = currentEvent.getEndTime();
                textBox4.Text = currentEvent.getReminder();
                textBox5.Text = currentEvent.getLocation();
                textBox7.Text = currentEvent.getDescription();
                eventID = currentEvent.getEventID();
            }
        }
        //cancel edit button
        private void button10_Click(object sender, EventArgs e)
        {
            emptyEventForm();
            panel1.Visible = false;
            button1.Enabled = true;
            button2.Enabled = true;
            button5.Enabled = true;
            button8.Enabled = true;
            button4.BackColor = DefaultBackColor;
            button10.Visible = false;
            button9.Visible = false;
        }
    }
}
