using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Interface representing a database broker for common database operations
    public interface IDBbroker
    {
        // Method to read data from the database
        List<List<string>> Read();

        // Method to search for data by ID in the database
        List<List<string>> SearchById(int ID);

        // Method to search for data by name in the database
        List<List<string>> SearchByName(string Name);

        // Method to search for data by both ID and name in the database
        List<List<string>> Search(int Id, string Name);

        // Method to update data in the database
        void Update(object x);
    }
}
