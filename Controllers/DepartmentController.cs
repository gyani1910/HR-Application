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
    public class DepartmentController : Controller{
        private readonly  ApplicationDbContext dbContext;
        public DepartmentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult getdepartmentdata(){
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> getdepartmentdata(AddDepartmentViewModel model){
            if(ModelState.IsValid){
                var department = new Department{
                    DepartmentName = model.DepartmentName
                };
                await dbContext.Departments.AddAsync(department);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("alldepartment", "Department");
        }

        [HttpGet]
        public async Task<IActionResult> alldepartment(){
            var departments = await dbContext.Departments.ToListAsync();
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            var department = await dbContext.Departments.FindAsync(id);
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department){
            dbContext.Departments.Update(department);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("alldepartment", "Department");
        }
        
        public async Task<IActionResult> Delete(int id){
            // // var department = await dbContext.Departments.FindAsync(id);
            // // dbContext.Departments.Remove(department);
            // // await dbContext.SaveChangesAsync();
            // return RedirectToAction("alldepartment", "Department");

            
   // Fetch the department to be deleted
            var department = await dbContext.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            // Find employees associated with this department
            var employees = await dbContext.Employees
                .Where(e => e.DepartmentID == id)
                .ToListAsync();

            // Fetch all salaries associated with employees
            var employeeIds = employees.Select(e => e.EmployeeID).ToList();
            var salaries = await dbContext.Salaries
                .Where(s => employeeIds.Contains(s.EmployeeID))
                .ToListAsync();

            // Remove each salary one by one
            foreach (var salary in salaries)
            {
                dbContext.Salaries.Remove(salary);
            }

            // Save changes to the database
            await dbContext.SaveChangesAsync();


            // Set DepartmentID to null for these employees
            foreach (var employee in employees)
            {
                employee.DepartmentID = null; 
                dbContext.Employees.Update(employee);
                            // Save changes to the database
                await dbContext.SaveChangesAsync();
            }


            // Remove the department
            dbContext.Departments.Remove(department);

            // Save changes to the database
            await dbContext.SaveChangesAsync();

            return RedirectToAction("alldepartment", "Department");
}

    }
}
