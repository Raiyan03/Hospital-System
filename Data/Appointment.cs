using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    public class Patient
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Disease { get; set; }
        public string Contact { get; set; }
        public Patient(string fName, string lName, string dob, string gender, string disease, string contact)
        {
            FName = fName;
            LName = lName;
            DOB = dob;
            Gender = gender;
            Disease = disease;
            Contact = contact;
        }
    }
}
