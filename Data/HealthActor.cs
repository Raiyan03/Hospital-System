using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Abstract class representing a generic health actor
    public abstract class HealthActor
    {
        // Private fields for actor ID, first name, and last name
        private int id;
        private string fName;
        private string lname;

        // Properties for accessing the private fields
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string FNAME
        {
            get { return fName; }
            set { fName = value; }
        }
        public string LNAME
        {
            get { return lname; }
            set { lname = value; }
        }

        // Parameterized constructor for creating a HealthActor with specified attributes
        public HealthActor(int id, string Fname, string Lname)
        {
            this.id = id;
            fName = Fname;
            lname = Lname;
        }

        // Default constructor
        public HealthActor()
        {
        }

        // Method to retrieve actor information as a list of strings
        public List<string> Get()
        {
            // Create a list containing ID, first name, and last name
            List<string> resultList = new List<string>
            {
                id.ToString(),
                fName,
                lname
            };

            return resultList;
        }
    }
}
