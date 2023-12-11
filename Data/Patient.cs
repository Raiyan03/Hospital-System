using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Class representing a patient, inheriting from HealthActor
    public class Patient : HealthActor
    {
        // Private fields for patient-specific attributes
        private string dob;
        private string gender;
        private string disease;
        private string phone;

        // Database broker for patient operations
        private PatientDBbroker broker = new PatientDBbroker();

        // Properties for accessing private fields
        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public string Disease
        {
            get { return disease; }
            set { disease = value; }
        }

        // Parameterized constructor for creating a patient with specified attributes
        public Patient(int id, string fName, string lName, string dob, string gender, string disease, string phone) : base(id, fName, lName)
        {
            DOB = dob;
            Gender = gender;
            Phone = phone;
            Disease = disease;
        }

        // Default constructor
        public Patient()
        {
        }

        // Method to validate a patient's existence based on ID
        public bool Validate(int id)
        {
            bool isValid = broker.Validate(id);
            return isValid;
        }

        // Method to manually create a list of patient attributes without calling the base class's ToList method
        public new List<string> Get()
        {
            List<string> patientList = new List<string>
            {
                ID.ToString(),
                FNAME,
                LNAME,
                DOB,
                Gender,
                Disease,
                Phone
            };

            return patientList;
        }

        // Method to parse a list of patient information into a list of Patient objects
        public List<Patient> Parse(List<List<string>> list)
        {
            List<Patient> result = new List<Patient>();
            foreach (List<string> row in list)
            {
                Patient pat = new Patient(Convert.ToInt32(row[0]), row[1], row[2], row[3], row[4], row[5], row[6]);
                result.Add(pat);
            }
            return result;
        }

        // Method to search for patients by ID in the database
        public List<Patient> SearchById(int id)
        {
            List<List<string>> list = broker.SearchById(id);
            return Parse(list);
        }

        // Method to search for patients by name in the database
        public List<Patient> SearchByName(string name)
        {
            List<List<string>> list = broker.SearchByName(name);
            return Parse(list);
        }

        // Method to search for patients by both ID and name in the database
        public List<Patient> Search(int id, string name)
        {
            List<List<string>> list = broker.SearchByName(name);
            return Parse(list);
        }

        // Method to update patient information in the database
        public void Update(object obj)
        {
            broker.Update(obj);
        }

        // Method to generate a new patient ID
        public int GenerateId()
        {
            List<List<string>> list = broker.Read();
            List<Patient> patients = Parse(list);
            int maxId = 0;

            // Find the maximum existing patient ID
            for (int i = 0; i < patients.Count; i++)
            {
                int currentId = patients[i].ID;
                if (currentId > maxId)
                {
                    maxId = currentId;
                }
            }
            int newId = (maxId + 1);

            return newId;
        }

        // Method to add a new patient to the database
        public void Add(object obj)
        {
            broker.Insert(obj);
        }
    }
}
