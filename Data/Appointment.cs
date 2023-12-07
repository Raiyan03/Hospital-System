using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    public class Appointment
    {
        public int Id { get; set; }

        public Appointment(int i) 
        {
            Id = i;
        }
    }
}
