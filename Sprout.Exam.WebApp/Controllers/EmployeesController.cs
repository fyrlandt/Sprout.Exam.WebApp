using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.WebApp.Models;
using Sprout.Exam.WebApp.Data;
using IdentityServer4.Models;
using Sprout.Exam.WebApp.Factories;
using System.Collections;
using System.Globalization;

namespace Sprout.Exam.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeContext _context;
        private EmployeeFactory employeeFactory;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
            employeeFactory = new EmployeeFactory();
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = _context.Employees.Where(e => e.IsDeleted == false);
            var result = await Task.FromResult(list);
            return Ok(result);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and fetch from the DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Employee employee = await Task.FromResult(_context.Employees.Find(id));
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and update changes to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(EditEmployeeDto input)
        {
            Employee employee = await Task.FromResult(_context.Employees.Find(input.Id));
            if (employee == null)
                return NotFound();

            employee.FullName = input.FullName;
            employee.Tin = input.Tin;
            employee.Birthdate = input.Birthdate;
            employee.EmployeeTypeId = input.TypeId;
            _context.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }

        /// <summary>
        /// Refactor this method to go through proper layers and insert employees to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDto input)
        {
            Employee employee = await Task.FromResult(employeeFactory.GetEmployee(input.TypeId));
            employee.FullName = input.FullName;
            employee.Tin = input.Tin;
            employee.Birthdate = input.Birthdate;
            _context.Employees.Add(employee);   
            _context.SaveChanges();
            return Created($"/api/employees/{employee.Id}", employee.Id);
        }


        /// <summary>
        /// Refactor this method to go through proper layers and perform soft deletion of an employee to the DB.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Employee employee = await Task.FromResult(_context.Employees.Find(id));

            if (employee == null) 
                return NotFound();

            employee.IsDeleted = true;
            _context.Update(employee);
            _context.SaveChanges();
            return Ok(id);
        }



        /// <summary>
        /// Refactor this method to go through proper layers and use Factory pattern
        /// </summary>
        /// <param name="id"></param>
        /// <param name="absentDays"></param>
        /// <param name="workedDays"></param>
        /// <returns></returns>
        [HttpPost("{id}/calculate")]
        public async Task<IActionResult> Calculate(CalculateSalaryDto input)
        {
            if (input.AbsentDays < 0 || input.WorkedDays < 0)
                return BadRequest();

            Employee employee = await Task.FromResult(_context.Employees.Find(input.Id));

            if (employee == null)
                return NotFound();

            var type = (EmployeeType)employee.EmployeeTypeId;
            switch (type)
            {
                case EmployeeType.Regular:
                    ((RegularEmployee)employee).DaysAbsent = input.AbsentDays;
                    break;
                case EmployeeType.Contractual:
                    ((ContractualEmployee)employee).DaysWorked = input.WorkedDays;
                    break;
            }
            return Ok(employee.ComputeSalary());

            //return type switch
            //{
            //    EmployeeType.Regular =>
                    //create computation for regular.
            //        Ok(25000),
            //    EmployeeType.Contractual =>
                    //create computation for contractual.
           //         Ok(20000),
            //    _ => NotFound("Employee Type not found")
            //};

        }

    }
}
