using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Represents a database broker for managing Doctor entities
    public class DoctorDBbroker : DBbroker, IDBbroker
    {
        // Default constructor
        public DoctorDBbroker()
        {

        }

        // Retrieve a list of all doctors from the database
        public List<List<string>> Read()
        {
            string query = "select * from HPdoctor";

            List<List<string>> list = Get(query);
            return list;
        }

        // Insert a new doctor into the database
        public void Insert(object x)
        {
            string query = $@"INSERT INTO HPDOCTOR (Doctor#, FNAME, LNAME, SPECIALITY)
                            VALUES ({((dynamic)x).Id}, '{((dynamic)x).Fname}', '{((dynamic)x).Lname}', '{((dynamic)x).speciality}')";

            Command(query);
        }

        // Update an existing doctor's information in the database
        public void Update(object x)
        {
            string query = $@"UPDATE HPDOCTOR
                SET FNAME = '{((dynamic)x).Fname}',
                    LNAME = '{((dynamic)x).Lname}',
                    SPECIALITY = '{((dynamic)x).speciality}'
                WHERE Doctor# = {((dynamic)x).Id}";

            Command(query);
        }

        // Search for doctors by name
        public List<List<string>> SearchByName(string Name)
        {
            string query = $"SELECT * FROM HPDOCTOR WHERE (Fname || ' ' || Lname) = '{Name}'";
            List<List<string>> list = Get(query);
            return list;
        }

        // Search for doctors by ID
        public List<List<string>> SearchById(int Id)
        {
            string query = $"SELECT * FROM HPDOCTOR WHERE DOCTOR# = {Id}";
            List<List<string>> list = Get(query);
            return list;
        }

        // Search for doctors by both ID and name
        public List<List<string>> Search(int Id, string Name)
        {
            string query = $"SELECT * FROM HPDOCTOR WHERE DOCTOR# = {Id} AND (Fname || ' ' || Lname) = '{Name}'";
            List<List<string>> list = Get(query);
            return list;
        }
    }
}
