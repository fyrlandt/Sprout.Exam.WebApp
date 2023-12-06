using Sprout.Exam.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Humanizer.In;

namespace Sprout.Exam.WebApp.Models
{
    public class RegularEmployee: Employee
    {
        private readonly decimal monthlySalary = 20000;

        [NotMapped]
        public decimal DaysAbsent { get; set; }

        public RegularEmployee()
        {
            EmployeeTypeId = (int)EmployeeType.Regular;
        }

        public override decimal ComputeSalary()
        {
            decimal netSalary = (monthlySalary - (DaysAbsent * (monthlySalary / 22)) - (monthlySalary * 0.12M));
            netSalary = Math.Round(netSalary, 2);
            return netSalary > 0 ? netSalary : 0;
        }
    }
}
