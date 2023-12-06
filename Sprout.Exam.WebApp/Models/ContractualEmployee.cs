using Sprout.Exam.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using static Humanizer.In;

namespace Sprout.Exam.WebApp.Models
{
    public class ContractualEmployee: Employee
    {
        private readonly decimal dailySalary = 500;

        [NotMapped]
        public decimal DaysWorked { get; set; }

        public ContractualEmployee()
        {
            EmployeeTypeId = (int)EmployeeType.Contractual;
        }

        public override decimal ComputeSalary()
        {
            return dailySalary * DaysWorked;
        }
    }
}
