using Sprout.Exam.WebApp.Models;

namespace Sprout.Exam.Tests;

public class ContractualEmployeeTest
{
    [Theory]
    [InlineData(0, 0.00)]
    [InlineData(4, 2000.00)]
    [InlineData(6.3, 3150.00)]
    [InlineData(50.00, 25000.00)]
    public void ComputeSalary_ReturnSalary(decimal workedDays, decimal expectedSalary)
    {
        ContractualEmployee contractualEmployee = new ContractualEmployee();
        contractualEmployee.DaysWorked = workedDays;

        decimal salary = contractualEmployee.ComputeSalary();

        Assert.Equal(expectedSalary, salary);
    }
}