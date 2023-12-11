using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Represents an Appointment in the hospital system
    public class Appointment
    {
        // Private fields to store appointment information
        private int aptId;
        private int patientId;
        private string patName;
        private string date;
        private string time;
        private string docName;

        // Instance of AppointmentDBbroker to interact with the database
        private AppointmentDBbroker broker = new AppointmentDBbroker();

        // Instance of Doctor class to handle doctor-related operations
        private Doctor DocController = new Doctor();

        // Properties for accessing private fields
        public int AptId
        {
            get { return aptId; }
            set { aptId = value; }
        }

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public string PatName
        {
            get { return patName; }
            set { patName = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }

        // Parameterized constructor for creating an Appointment object
        public Appointment(int aptId, int patientId, string patName, string date, string time, string docName)
        {
            AptId = aptId;
            PatientId = patientId;
            PatName = patName;
            Date = date;
            Time = time;
            DocName = docName;
        }

        // Default constructor
        public Appointment()
        {
        }

        // Method to generate a new unique appointment ID
        public int generateID()
        {
            // Retrieve existing appointments from the database
            List<Appointment> appointments = new List<Appointment>();
            List<List<string>> list = broker.Read();
            appointments = parse(list);

            // Find the maximum appointment ID
            int maxId = 0;
            foreach (Appointment appointment in appointments)
            {
                if (appointment.AptId > maxId)
                {
                    maxId = appointment.AptId;
                }
            }

            // Generate a new ID (400-499 range) ensuring uniqueness
            int newId = maxId + 1;
            if (newId < 400 || newId > 499)
            {
                newId = 400;
            }
            return newId;
        }

        // Method to parse a list of string lists into a list of Appointments
        public List<Appointment> parse(List<List<string>> list)
        {
            List<Appointment> result = new List<Appointment>();
            foreach (List<string> row in list)
            {
                // Convert string values to their respective types
                int id = Convert.ToInt32(row[0]);
                int patid = Convert.ToInt32(row[1]);
                string patname = Convert.ToString(row[2]);
                string date = Convert.ToString(row[3]);
                string time = Convert.ToString(row[4]);
                string docname = Convert.ToString(row[5]);

                // Create an Appointment object and add it to the result list
                Appointment apppointment = new Appointment(id, patid, patname, date, time, docname);
                result.Add(apppointment);
            }
            return result;
        }

        // Method to search for appointments by appointment ID
        public List<Appointment> SearchByAptID(int aptId)
        {
            List<List<string>> appointments = broker.SearchByAptid(aptId);
            return parse(appointments);
        }

        // Method to search for appointments by patient ID
        public List<Appointment> SearchByID(int id)
        {
            List<List<string>> appointments = broker.SearchById(id);
            return parse(appointments);
        }

        // Method to search for appointments by patient name
        public List<Appointment> SearchByName(string name)
        {
            List<List<string>> appointments = broker.SearchByName(name);
            return parse(appointments);
        }

        // Method to search for appointments by both ID and name
        public List<Appointment> Search(int id, string name)
        {
            List<List<string>> appointments = broker.Search(id, name);
            return parse(appointments);
        }

        // Method to find available doctors for a given date, time, and patient ID
        public List<Doctor> AvailableDocs(string date, string time, int patId)
        {
            List<List<string>> docs = broker.AvailableDoc(date, time, patId);
            return DocController.parse(docs);
        }

        // Method to find available doctors for a given date and time
        public List<Doctor> AvailableDocs(string date, string time)
        {
            List<List<string>> docs = broker.AvailableDoc(date, time);
            return DocController.parse(docs);
        }

        // Method to update an appointment with a new doctor, date, and time
        public void update(int aptcode, int docId, string date, string time)
        {
            // Create an anonymous object with update information
            Object apt = new
            {
                aptCode = aptcode,
                DocId = docId,
                Date = date,
                Time = time
            };

            // Update the appointment in the database
            broker.Update(apt);
        }

        // Method to cancel an appointment by ID
        public void Cancel(int id)
        {
            broker.CancelAppointment(id);
        }

        // Method to save a new appointment with specified details
        public void Save(int apId, string date, string time, int PatId, int docId)


