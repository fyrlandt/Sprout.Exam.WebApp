using Sprout.Exam.WebApp.Models;
using System;

namespace Sprout.Exam.WebApp.Factories
{
    public class EmployeeFactory
    {
        public Employee GetEmployee(int type)
        {
            switch(type)
            {
                case 1:
                    return new RegularEmployee();
                case 2:
                    return new ContractualEmployee();
                default:
                    throw new ApplicationException("Invalid employee type.");
            }
        }
    }
}
