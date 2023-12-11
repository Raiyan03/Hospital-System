using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Represents a Doctor, inheriting from the HealthActor base class
    public class Doctor : HealthActor
    {
        // Private field to store the doctor's speciality
        private string speciality;

        // Instance of DoctorDBbroker to interact with the database
        private DoctorDBbroker broker = new DoctorDBbroker();

        // Property for accessing the speciality field
        public string Speciality
        {
            get { return speciality; }
            set { speciality = value; }
        }

        // Parameterized constructor for creating a Doctor object with specified attributes
        public Doctor(int id, string Fname, string Lname, string speciality) : base(id, Fname, Lname)
        {
            Speciality = speciality;
        }

        // Default constructor
        public Doctor()
        {
        }

        // Method to parse a list of string lists into a list of Doctor objects
        public List<Doctor> parse(List<List<string>> list)
        {
            List<Doctor> result = new List<Doctor>();
            foreach (List<string> row in list)
            {
                Doctor doctor = new Doctor(Convert.ToInt32(row[0]), row[1], row[2], row[3]);
                result.Add(doctor);
            }
            return result;
        }

        // Method to retrieve all doctors from the database
        public List<Doctor> ReadAll()
        {
            List<List<string>> Doctors = broker.Read();
            return parse(Doctors);
        }

        // Method to search for doctors by ID
        public List<Doctor> SearcByID(int id)
        {
            List<List<string>> list = broker.SearchById(id);
            return parse(list);
        }

        // Method to search for doctors by name
        public List<Doctor> SearchByName(string name)
        {
            List<List<string>> list = broker.SearchByName(name);
            return parse(list);
        }

        // Method to search for doctors by both ID and name
        public List<Doctor> Search(int id, string name)
        {
            List<List<string>> list = broker.Search(id, name);
            return parse(list);
        }

        // Method to update a doctor's information in the database
        public void Update(object obj)
        {
            broker.Update(obj);
        }

        // Method to generate a new unique doctor ID
        public int GenerateId()
        {
            List<List<string>> list = broker.Read();
            List<Doctor> Doctors = parse(list);

            if (Doctors.Count == 0)
            {
                return 1;
            }

            int maxId = Doctors[0].ID;
            foreach (var doctor in Doctors)
            {
                if (doctor.ID > maxId)
                {
                    maxId = doctor.ID;
                }
            }

            int newId = maxId + 1;
            return newId;
        }

        // Method to add a new doctor to the database
        public void Add(object obj)
        {
            broker.Insert(obj);
        }

        // Method to convert Doctor object to a list of strings
        public new List<string> ToList()
        {
            List<string> doctorList = new List<string>
            {
                ID.ToString(),
                FNAME,
                LNAME,
                Speciality
            };

            return doctorList;
        }
    }
}
