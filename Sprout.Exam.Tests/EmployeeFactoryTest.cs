using Sprout.Exam.WebApp.Factories;
using Sprout.Exam.WebApp.Models;

namespace Sprout.Exam.Tests;
public class EmployeeFactoryTest
{
    [Fact]
    public void GetEmployee_RegularEmployee()
    {
        EmployeeFactory employeeFactory = new EmployeeFactory();
        Employee employee = employeeFactory.GetEmployee(1);

        Assert.True(employee.GetType() == typeof(RegularEmployee));
    }

    [Fact]
    public void GetEmployee_ContractualEmployee()
    {
        EmployeeFactory employeeFactory = new EmployeeFactory();
        Employee employee = employeeFactory.GetEmployee(2);

        Assert.True(employee.GetType() == typeof(ContractualEmployee));
    }
}