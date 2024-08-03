using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using NewApp1.Models;
using NewApp1.Models.Entities;


using System;
using System.Threading.Tasks;


namespace NewApp1.Controllers{

    public class EmployeeController : Controller{
        private readonly  ApplicationDbContext dbContext;
        public EmployeeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AddData(){
            Console.WriteLine("AddData");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddData(AddEmployeeViewModel model){
            Console.WriteLine(model.FirstName);
                var employee = new Employee{
                    // EmployeeID = model.EmployeeID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DepartmentID = model.DepartmentID
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
        public async Task<IActionResult> allemployee(){
            var employees = await dbContext.Employees.ToListAsync();
            return View(employees);
        }
        
        public async Task<IActionResult> Delete(int id){
            var employee = await dbContext.Employees.FindAsync(id);
            dbContext.Employees.Remove(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("allemployee", "Employee");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            var employee = await dbContext.Employees.FindAsync(id);
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee){
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("allemployee", "Employee");
        }
    }
}