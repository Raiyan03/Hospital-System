using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    public class InvalidDateFormatException : Exception
    {
        public InvalidDateFormatException() : base("Invalid date format. Please use DD-MM-YY format.") { }
    }
}
