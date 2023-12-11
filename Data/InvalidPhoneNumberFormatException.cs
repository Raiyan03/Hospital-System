using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Custom exception class for handling invalid phone number format errors
    public class InvalidPhoneNumberFormatException : Exception
    {
        // Constructor with a default error message
        public InvalidPhoneNumberFormatException() : base("Invalid phone number format. Please enter a valid phone number.") { }
    }
}
