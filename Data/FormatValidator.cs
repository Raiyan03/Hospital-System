﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Data
{
    // Static class for validating formats
    public static class FormatValidator
    {
        // Method to check if the provided string follows a valid date format (DD-MM-YY)
        public static bool IsValidDateFormat(string date)
        {
            // Simple check for DD-MM-YY format using regular expression
            if (string.IsNullOrEmpty(date))
            {
                return false;
            }
            else
            {
                bool isValid = System.Text.RegularExpressions.Regex.IsMatch(date, @"^\d{2}-\d{2}-\d{2}$");
                return isValid;
            }
        }

        // Method to check if the provided string is a valid phone number (not more than 10 digits)
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Simple check for not more than 10 digits and all characters are digits
            if (phoneNumber == null)
            {
                return false;
            }
            else
            {
                bool isValid = phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
                return isValid;
            }
        }
    }
}
