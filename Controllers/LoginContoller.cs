// Controllers/LoginController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NewApp1.Models.Entities;
using NewApp1.Models;

namespace NewApp1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoginController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Initial() // This method corresponds to Initial.cshtml
        {
            if (TempData["Session"] != null)
            {
                ViewBag.Session = TempData["Session"];
            }
            else
            {
                ViewBag.Session = false;
            }
            // ViewBag.Session = TempData["Session"];
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Initial(loginViewModel model) // Ensure this matches the view model name
        {
                var user = await dbContext.Logins.FirstOrDefaultAsync(u => u.username == model.Username && u.Password == model.Password);
                Console.WriteLine(model.Username, model.Password);
                bool userExists = user != null;
                // Validate user credentials
                if (userExists)
                {
                    TempData["Session"] = true;
                    // Redirect to a different action or page
                    return RedirectToAction("allemployee", "Employee");
                }
                else
                {
                    // ModelState.AddModelError("", "Invalid username or password");
                    // error.ErrorMessage = "Invalid username or password";
                    // return RedirectToAction("Initial", "Login");
                    ViewBag.Session = false;
                    ViewBag.error = "Invalid username or password";
                    return View();
                }
            // return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Login login)
        {
            dbContext.Logins.Add(login);
            dbContext.SaveChanges();
            TempData["Session"] = false;
            return RedirectToAction("Initial", "Login");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            TempData["Session"] = false;
            return RedirectToAction("Initial", "Login");
        }
        // private bool ValidateUser(string username, string password)
        // {
        //     // Check if the user exists in the database
        //     var user = dbContext.Logins.FirstOrDefault(u => u.username == username && u.Password == password);
        //     return user != null;
        // }
    }
}
