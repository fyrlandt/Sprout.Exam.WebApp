using Sprout.Exam.WebApp.Models;

namespace Sprout.Exam.Tests;
public class RegularEmployeeTest
{
    [Fact]
    public void ComputeSalary_Zero_ReturnsSalary()
    {
        var carService = new RegularEmployee();

        var models = carService.GetModels("Ford");

        Assert.Single(models);
        Assert.Single(models, "Mustang");
    }
}