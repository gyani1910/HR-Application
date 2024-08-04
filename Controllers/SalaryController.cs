using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using NewApp1.Models;
using NewApp1.Models.Entities;
using Microsoft.AspNetCore.Authorization;

using System;
using System.Threading.Tasks;


namespace NewApp1.Controllers{

    [Authorize]
    public class SalaryController : Controller{
        private readonly  ApplicationDbContext dbContext;
        public SalaryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> allsalary(){
            var salaries = await dbContext.Salaries.ToListAsync();
            Console.WriteLine("salaries");
            return View(salaries);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            var salary = await dbContext.Salaries.FindAsync(id);
            return View(salary);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(Salary salary){
            var salary1 = await dbContext.Salaries.FindAsync(salary.SalaryID);
            salary1.EmployeeID = salary.EmployeeID;
            salary1.SalaryValue = salary.SalaryValue;
            dbContext.Salaries.Update(salary1);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("allsalary", "Salary");
        }

        public async Task<IActionResult> Delete(int id){
            var salary = await dbContext.Salaries.FindAsync(id);
            dbContext.Salaries.Remove(salary);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("allsalary", "Salary");
        }
    }
}

