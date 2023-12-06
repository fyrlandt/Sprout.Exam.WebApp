using Sprout.Exam.WebApp.Models;

namespace Sprout.Exam.Tests;
public class RegularEmployeeTest
{
    [Theory]
    [InlineData(0, 17600.00)]
    [InlineData(5, 13054.55)]
    [InlineData(4.3, 13690.91)]
    [InlineData(50, 0.00)]
    public void ComputeSalary_ReturnSalary(decimal absentDays, decimal expectedSalary)
    {
        RegularEmployee regularEmployee = new RegularEmployee();
        regularEmployee.DaysAbsent = absentDays;

        decimal salary = regularEmployee.ComputeSalary();

        Assert.Equal(expectedSalary, salary);
    }

}