using System;

namespace Sprout.Exam.WebApp.Models
{
    public abstract class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Tin { get; set; }
        public int EmployeeTypeId { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsDeleted { get; set; }

        public abstract decimal computeSalary();
    }
}
