using Sprout.Exam.Business.DataTransferObjects;
using System;
using System.Text.RegularExpressions;

namespace Sprout.Exam.WebApp.Utils
{
    public class ValidationUtil
    {
        public static bool IsInputValid(BaseSaveEmployeeDto input)
        {
            return !string.IsNullOrWhiteSpace(input.FullName) &&
                !string.IsNullOrWhiteSpace(input.Tin) && Regex.Match(input.Tin, @"^[\d-]+$").Success &&
                input.Birthdate <= DateTime.Now;
        }
    }
}
