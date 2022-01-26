using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual_Project
{
    class Event
    {
        //event details
        String title;
        String startTime;
        String endTime;
        String reminder;
        String location;
        String date;
        String description;
        String empID = "1";
        //not used in individual project so we will not use this.
        //User[] attendees;
        int eventID;

        //basic constructor for event class.
        public Event(String t, String st, String et, String r, String l, String d, String ds)
        {
            title = t;
            startTime = st;
            endTime = et;
            reminder = r;
            location = l;
            date = d;
            description = ds;
        }
        //default constructor
        public Event()
        {

        }

        //uses insert SQL statement to save new event.
        public void saveEvent()
        {
            //set up
            string connStr = "server=Removed;user=stu_csc340;database=Removed;port=3306;password=Removed;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL for saveEvent...");
                conn.Open();
                string sql = "INSERT INTO smith_event (title, date, starttime, endtime, reminder, description, location, empid) " + 
                    "VALUES (@title, @date, @startTime, @endTime, @reminder, @description, @location, @empid)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@reminder", reminder);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@empid", empID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
        //checks for time conflicts with new event
        public bool checkConflict(ArrayList eList)
        {
            if (eList.Count == 0)
            {
                return true;
            }
                
            for (int i=0; i<eList.Count; i++)
            {
                Event thisEvent = (Event)eList[i];
                
                if (startTime.CompareTo(thisEvent.getEndTime()) >= 0 || endTime.CompareTo(thisEvent.getStartTime()) <= 0)
                    continue;
                else
                    return false;
            }
            return true;
        }

        //takes input from text boxes and updates values in an Event object.
        public void updateEventValue(String t, String st, String et, String r, String l, String d, String ds)
        {
            title = t;
            startTime = st;
            endTime = et;
            reminder = r;
            location = l;
            date = d;
            description = ds;
        }
        //get methods for specific parts of an event.
        public int getEventID()
        {
            return eventID;
        }
        public String getDate()
        {
            return date;
        }
        public String getStartTime()
        {
            return startTime;
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
        //uses a select SQL statement to pull all events on a given date.
        public static ArrayList getEventList(string dateString)
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=Removed;user=stu_csc340;database=Removed;port=3306;password=Removed;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL for getEventList...");
                conn.Open();
                string sql = "SELECT * FROM smith_event WHERE date=@myDate AND empid='1' ORDER BY startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", dateString);
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
                newEvent.title = row["title"].ToString();
                newEvent.date = row["date"].ToString();
                newEvent.startTime = row["startTime"].ToString();
                newEvent.endTime = row["endTime"].ToString();
                newEvent.reminder = row["reminder"].ToString();
                //newEvent.endTime = Int32.Parse(row["endTime"].ToString());
                newEvent.description = row["description"].ToString();
                newEvent.location = row["location"].ToString();
                newEvent.eventID = Int32.Parse(row["eventid"].ToString());
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }
        //uses a delete SQL statement to remove selected event from database.
        public void deleteEvent()
        {
            Console.WriteLine("ID of deleted event: " + this.eventID);

            
            string connStr = "server=Removed;user=stu_csc340;database=Removed;port=3306;password=Removed;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM smith_event WHERE eventid = @eventID;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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
        //used by edit event to update an existing event
        public void updateEvent(int eventID)
        {
            Console.WriteLine("Event ID is " + eventID.ToString());
            string connStr = "server=Removed;user=stu_csc340;database=Removed;port=3306;password=Removed;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "UPDATE smith_event SET title=@title, starttime=@starttime, endtime=@endtime, reminder=@reminder, description=@description, location=@location WHERE eventid=@eventid;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                cmd.Parameters.AddWithValue("@endTime", endTime);
                cmd.Parameters.AddWithValue("@reminder", reminder);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@location", location);
                cmd.Parameters.AddWithValue("@eventid", eventID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

        }
        //uses a select SQL statement to pull all events that take place within a given month.
        public static ArrayList getEventListMonth(string dateString)
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            String mYear = dateString + '%';
            string connStr = "server=Removed;user=stu_csc340;database=Removed;port=3306;password=Removed;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine(dateString);
                string sql = "SELECT * FROM smith_event WHERE (date LIKE @myDate) AND empid='1' ORDER BY date ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myDate", mYear);
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
                newEvent.title = row["title"].ToString();
                newEvent.date = row["date"].ToString();
                newEvent.startTime = row["startTime"].ToString();
                newEvent.endTime = row["endTime"].ToString();
                newEvent.reminder = row["reminder"].ToString();
                //newEvent.endTime = Int32.Parse(row["endTime"].ToString());
                newEvent.description = row["description"].ToString();
                newEvent.location = row["location"].ToString();
                newEvent.eventID = Int32.Parse(row["eventid"].ToString());
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }
        //used in edit event to check conflicts with existing events that are not the event being edited.
        
        public static ArrayList getModifiedList(int eventID, String dateString)
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=Removed;user=stu_csc340;database=Removed;port=3306;password=Removed;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM smith_event WHERE NOT (eventid = @eventID) AND empid='1' AND date=@mydate ORDER BY startTime ASC";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@eventID", eventID);
                cmd.Parameters.AddWithValue("@mydate", dateString);
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
                newEvent.title = row["title"].ToString();
                newEvent.date = row["date"].ToString();
                newEvent.startTime = row["startTime"].ToString();
                newEvent.endTime = row["endTime"].ToString();
                newEvent.reminder = row["reminder"].ToString();
                //newEvent.endTime = Int32.Parse(row["endTime"].ToString());
                newEvent.description = row["description"].ToString();
                newEvent.location = row["location"].ToString();
                newEvent.eventID = Int32.Parse(row["eventid"].ToString());
                eventList.Add(newEvent);
            }
            return eventList;  //return the event list
        }
    }
}
