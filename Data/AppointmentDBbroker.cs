using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Represents a database broker for managing appointments
    public class AppointmentDBbroker : DBbroker, IDBbroker
    {
        // Default constructor
        public AppointmentDBbroker()
        {
        }

        // Retrieve a list of appointments from the database
        public List<List<string>> Read()
        {
            string query = "Select a.appointment#, p.patient#, p.fname || ' ' || p.Lname, a.apt_date, a.apt_time, d.fname || ' ' || d.Lname\r\nfrom hpappointment a\r\nJoin hppatient p ON a.patient# = p.patient#\r\nJoin hpdoctor d ON a.doctor# = d.doctor#";

            List<List<string>> list = Get(query);
            return list;
        }

        // Insert a new appointment into the database
        public void Insert(int aptId, string date, string time, int PatId, int docId)
        {
            string query = $"INSERT INTO health_schema.HPAppointment(Appointment#, apt_Date, apt_Time, Patient#, Doctor#, isActive) " +
                           $"VALUES({aptId}, '{date}', '{time}', {PatId}, {docId}, 1)";

            Command(query);
        }

        // Update an existing appointment in the database
        public void Update(object x)
        {
            string query = $@"
        UPDATE health_schema.HPAppointment
        SET apt_Date = '{((dynamic)x).Date}',
            apt_Time = '{((dynamic)x).Time}',
            Doctor# = {((dynamic)x).DocId}
        WHERE Appointment# = {((dynamic)x).aptCode}";

            Command(query);
        }

        // Search for appointments by patient name
        public List<List<string>> SearchByName(string Name)
        {
            string query = $"Select a.appointment#, p.patient#, p.fname || ' ' || p.Lname, a.apt_date, a.apt_time, d.fname || ' ' || d.Lname\r\nfrom hpappointment a\r\nJoin hppatient p ON a.patient# = p.patient#\r\nJoin hpdoctor d ON a.doctor# = d.doctor#\r\nwhere (p.fname || ' ' || p.Lname = '{Name}' AND a.isactive = 1)";
            List<List<string>> list = Get(query);
            return list;
        }

        // Search for appointments by patient ID
        public List<List<string>> SearchById(int Id)
        {
            string query = $"SELECT a.appointment#, p.patient#, p.fname || ' ' || p.Lname, a.apt_date, a.apt_time, d.fname || ' ' || d.Lname\r\nFROM health_schema.HPAppointment a\r\nJOIN health_schema.HPPatient p ON a.patient# = p.patient#\r\nJOIN health_schema.HPDoctor d ON a.doctor# = d.doctor#\r\nWHERE a.patient# = {Id} AND a.isactive = 1";
            List<List<string>> list = Get(query);
            return list;
        }

        // Search for appointments by both patient ID and name
        public List<List<string>> Search(int Id, string Name)
        {
            string query = $"Select a.appointment#, p.patient#, p.fname || ' ' || p.Lname, a.apt_date, a.apt_time, d.fname || ' ' || d.Lname\r\nfrom hpappointment a\r\nJoin hppatient p ON a.patient# = {Id}\r\nJoin hpdoctor d ON a.doctor# = d.doctor#\r\nwhere (p.fname || ' ' || p.Lname = '{Name}') where a.Isactive = 1";
            List<List<string>> list = Get(query);
            return list;
        }

        // Search for appointments by appointment ID
        public List<List<string>> SearchByAptid(int Id)
        {
            string query = $"Select a.appointment#, p.patient#, p.fname || ' ' || p.Lname, a.apt_date, a.apt_time, d.fname || ' ' || d.Lname\r\nfrom hpappointment a\r\nJoin hppatient p ON a.patient# = p.patient#\r\nJoin hpdoctor d ON a.doctor# = d.doctor#\r\nwhere a.appointment# = {Id} AND a.isactive = 1";
            List<List<string>> list = Get(query);
            return list;
        }

        // Find available doctors for a given date, time, and patient ID
        public List<List<string>> AvailableDoc(string date, string time, int patientId)
        {
            string query = $"SELECT DISTINCT d.doctor#, d.Fname, d.Lname, d.speciality " +
                   $"FROM health_schema.HPDoctor d " +
                   $"LEFT JOIN health_schema.HPAppointment a ON d.doctor# = a.Doctor# " +
                   $"WHERE NOT EXISTS (" +
                   $"    SELECT 1 " +
                   $"    FROM health_schema.HPAppointment " +
                   $"    WHERE Doctor# = d.doctor# " +
                   $"    AND apt_Date = '{date}' " +
                   $"    AND apt_Time = '{time}' " +
                   $"    AND isActive = 1 " +
                   $"    AND Patient# != {patientId}) " +
                   $"ORDER BY d.doctor#";
            List<List<string>> list = Get(query);
            return list;
        }

        // Find available doctors for a given date and time
        public List<List<string>> AvailableDoc(string date, string time)
        {
            string query = $"SELECT DISTINCT d.doctor#, d.Fname, d.Lname, d.speciality " +
            $"FROM health_schema.HPDoctor d " +
            $"LEFT JOIN health_schema.HPAppointment a ON d.doctor# = a.Doctor# " +
            $"WHERE NOT EXISTS (" +
            $"    SELECT 1 " +
            $"    FROM health_schema.HPAppointment " +
            $"    WHERE Doctor# = d.doctor# " +
            $"    AND apt_Date = '{date}' " +
            $"    AND apt_Time = '{time}' " +
            $"    AND isActive = 1 )" +
            $"ORDER BY d.doctor#";
            List<List<string>> list = Get(query);
            return list;
        }

        // Cancel an appointment by setting it as inactive
        public void CancelAppointment(int Id)
        {
            string query = $"UPDATE hpappointment" +
                $"  set isActive = 0" +
                $"  where appointment# = {Id}";
            Command(query);
        }
    }
}
