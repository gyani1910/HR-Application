// // Controllers/LoginController.cs
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using System.Linq;
// using NewApp1.Models.Entities;
// using NewApp1.Models;

// namespace NewApp1.Controllers
// {
//     public class LoginController : Controller
//     {
//         private readonly ApplicationDbContext dbContext;

//         public LoginController(ApplicationDbContext dbContext)
//         {
//             this.dbContext = dbContext;
//         }

//         [HttpGet]
//         public IActionResult Initial() // This method corresponds to Initial.cshtml
//         {
//             if (TempData["Session"] != null)
//             {
//                 ViewBag.Session = TempData["Session"];
//             }
//             else
//             {
//                 ViewBag.Session = false;
//             }
//             // ViewBag.Session = TempData["Session"];
//             return View();
//         }


//         [HttpPost]
//         public async Task<IActionResult> Initial(loginViewModel model) // Ensure this matches the view model name
//         {
//                 var user = await dbContext.Logins.FirstOrDefaultAsync(u => u.username == model.Username && u.Password == model.Password);
//                 Console.WriteLine(model.Username, model.Password);
//                 bool userExists = user != null;
//                 // Validate user credentials
//                 if (userExists)
//                 {
//                     TempData["Session"] = true;
//                     // Redirect to a different action or page
//                     return RedirectToAction("allemployee", "Employee");
//                 }
//                 else
//                 {
//                     // ModelState.AddModelError("", "Invalid username or password");
//                     // error.ErrorMessage = "Invalid username or password";
//                     // return RedirectToAction("Initial", "Login");
//                     ViewBag.Session = false;
//                     ViewBag.error = "Invalid username or password";
//                     return View();
//                 }
//             // return View(model);
//         }

//         [HttpGet]
//         public IActionResult Register()
//         {
//             return View();
//         }

//         [HttpPost]
//         public async Task<IActionResult> Register(Login login)
//         {
//             dbContext.Logins.Add(login);
//             dbContext.SaveChanges();
//             TempData["Session"] = false;
//             return RedirectToAction("Initial", "Login");
//         }

//         [HttpGet]
//         public IActionResult Logout()
//         {
//             TempData["Session"] = false;
//             return RedirectToAction("Initial", "Login");
//         }
//         // private bool ValidateUser(string username, string password)
//         // {
//         //     // Check if the user exists in the database
//         //     var user = dbContext.Logins.FirstOrDefault(u => u.username == username && u.Password == password);
//         //     return user != null;
//         // }
//     }
// }

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewApp1.Models;
using NewApp1.Models.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

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
        public IActionResult Initial()
        {
            // if (TempData["Message"] != null)
            // {
            //     ViewBag.error = TempData["Message"];
            // }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Initial(loginViewModel model)
        {

            var user = await dbContext.Logins
                .FirstOrDefaultAsync(u => u.username == model.Username && u.Password == model.Password);

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.username),
                    // Add other claims if necessary
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Optionally add authentication properties
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);

                // TempData["M"] = "1";
                return RedirectToAction("alldepartment", "Department"); // Redirect to Home page or any other page
            }
            else
            {
                // ModelState.AddModelError("", "Invalid username or password");
                ViewBag.error = "Invalid username or password";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Login login)
        {
            var userExists = await dbContext.Logins.AnyAsync(u => u.username == login.username);
            if (userExists)
            {
                TempData["Message"] = "User already exists";
                return RedirectToAction("Initial");
            }
            dbContext.Logins.Add(login);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("Initial");
        }
        
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Initial");
        }
    }
}


