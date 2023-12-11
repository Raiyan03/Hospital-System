using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Data
{
    // Class representing a database broker for patient operations, inheriting from DBbroker and implementing IDBbroker
    public class PatientDBbroker : DBbroker, IDBbroker
    {
        // Default constructor
        public PatientDBbroker()
        {

        }

        // Method to read all patient data from the database
        public List<List<string>> Read()
        {
            string query = "select * from HPpatient";
            List<List<string>> list = Get(query);
            return list;
        }

        // Method to insert patient data into the database
        public void Insert(object x)
        {
            string query1 = $@"INSERT INTO HPPATIENT (Patient#, FNAME, LNAME, DOB, GENDER, DISEASE, CONTACT)
                            VALUES({((dynamic)x).id}, '{((dynamic)x).fname}', '{((dynamic)x).lname}', '{((dynamic)x).dob}', '{((dynamic)x).gender}', '{((dynamic)x).disease}', '{((dynamic)x).contact}' )";
            Command(query1);
        }

        // Method to update patient data in the database
        public void Update(object x)
        {
            string query = $@"
    UPDATE health_schema.HPpatient
    SET FNAME = '{((dynamic)x).Fname}',
        LNAME = '{((dynamic)x).Lname}',
        DOB = '{((dynamic)x).DOB}',
        Gender = '{((dynamic)x).Gender}',
        Disease = '{((dynamic)x).Disease}',
        Contact = '{((dynamic)x).Phone}'
    WHERE Patient# = {((dynamic)x).id}";

            Command(query);
        }

        // Method to search for patient data by name in the database
        public List<List<string>> SearchByName(string Name)
        {
            string query = $"Select * from hppatient" +
                           $" where (Fname || ' ' || Lname) = '{Name}'";
            List<List<string>> list = Get(query);
            return list;
        }

        // Method to search for patient data by ID in the database
        public List<List<string>> SearchById(int Id)
        {
            string query = $"Select * from hppatient" +
                           $" where PATIENT# = {Id}";
            List<List<string>> list = Get(query);
            return list;
        }

        // Method to search for patient data by both ID and name in the database
        public List<List<string>> Search(int Id, string Name)
        {
            string query = $"Select * from hppatient" +
                           $" where PATIENT# = {Id} AND where (Fname || ' ' || Lname = '{Name}'";
            List<List<string>> list = Get(query);
            return list;
        }

        // Method to validate the existence of a patient based on ID
        public bool Validate(int id)
        {
            string query = $"SELECT * FROM HPPATIENT" +
                $"  WHERE PATIENT# = {id}";
            List<List<string>> list = Get(query);

            // Check if the list contains any data, indicating the existence of the patient
            if (list[0].Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
