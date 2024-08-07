using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering; 
using NewApp1.Models;
using NewApp1.Models.Entities;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

using System;
using System.Threading.Tasks;


namespace NewApp1.Controllers{

    [Authorize]
    public class EmployeeController : Controller{
        private readonly  ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AddData(){
            // Console.WriteLine("AddData");
            // return View();
            // Fetch departments for dropdown
            var departments =  await dbContext.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddData(AddEmployeeViewModel model)
        {
            Console.WriteLine(model.FirstName);
                var employee = new Employee{
                    // EmployeeID = model.EmployeeID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DepartmentID = model.DepartmentID,
                    Email = model.Email,
                    Address = model.Address
                };
                await dbContext.Employees.AddAsync(employee);
                await dbContext.SaveChangesAsync();
            
                var salary = new Salary{
                    SalaryValue = model.SalaryValue,
                    EmployeeID = employee.EmployeeID
                };
                await dbContext.Salaries.AddAsync(salary);
                await dbContext.SaveChangesAsync();
                
            return RedirectToAction("allemployee", "Employee");

        }

        [HttpGet]
        public async Task<IActionResult> allemployee()
        {
            var departments = await dbContext.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName");
            var employees = await dbContext.Employees.ToListAsync();


            // var employees = await dbContext.Employees.ToListAsync();
            return View(employees);
        }
        
        public async Task<IActionResult> Delete(int id){
            Employee employee = await dbContext.Employees.FindAsync(id);
            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("allemployee", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            // var employee = await dbContext.Employees.FindAsync(id);
            // return View(employee);

            var employee = dbContext.Employees.Find(id);
            // Fetch departments and create a SelectList
            var departments = await dbContext.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(dbContext.Departments, "DepartmentID", "DepartmentName");

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("allemployee", "Employee");
        }


        [HttpGet]
        public async Task<IActionResult> Search(string searchTerm, int? departmentID)
        {
            // Start with all employees as IQueryable
            IQueryable<Employee> query = dbContext.Employees;

            // Apply filtering based on search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(e => e.FirstName.Contains(searchTerm) ||
                                        e.LastName.Contains(searchTerm) ||
                                        e.Email.Contains(searchTerm) || // Include more fields if necessary
                                        e.Address.Contains(searchTerm));
            }

            // Apply filtering based on department ID
            if (departmentID.HasValue)
            {
                query = query.Where(e => e.DepartmentID == departmentID);
            }

            // Execute the query and get the results as a list
            var employees = await query.ToListAsync();

            // Return the view with the filtered list of employees
            var departments = await dbContext.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName");
            return View(employees);
        }

    }
}


