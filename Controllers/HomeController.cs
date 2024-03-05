using AspCoreWebAppMVC.Data;
using AspCoreWebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using AspCoreWebAppMVC.Repositories;
using AspCoreWebAppMVC.Repositories.Implementation;
using AspCoreWebAppMVC.Repositories.Interfaces;

namespace AspCoreWebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private IUser _userrepo;

        public HomeController(IUser model)
        {
            _userrepo = model;
        }

        public async Task<IActionResult> AllUserList()
        {
            var users = await _userrepo.GetAllUser();
            return View(users);
        }



        public IActionResult AddUser()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddUser(User model)
        //{
        //    if (model.PdfFile != null && model.PdfFile.Length > 0)
        //    {
        //        // Read the contents
        //        using (var ms = new MemoryStream())
        //        {
        //            model.PdfFile.CopyTo(ms);
        //            // Convert the contents to a base64-encoded string
        //            model.PdfBase64Data = Convert.ToBase64String(ms.ToArray());
        //        }
        //    }
        //    var user = new User
        //    {
        //        Name = model.Name,
        //        PhoneNumber = model.PhoneNumber,
        //        Address = model.Address,
        //        PdfBase64Data = model.PdfBase64Data 
        //    };
        //    context.User.Add(user);
        //    context.SaveChanges();
        //    return RedirectToAction("AllUserList", "Home");
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddUser(User user, IFormFile pdfFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Call the CreateUser method to handle user creation
        //        await _userrepo.CreateUser(user, user.PdfFile);

        //        // Redirect to the action to display all users
        //        return RedirectToAction(nameof(AllUserList));
        //    }
        //    else
        //    {
        //        // If model state is not valid, return the view with the user object
        //        return View(user);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            int id = await _userrepo.CreateUser(user);
            if (id > 0)
            {
                ModelState.Clear();
                ViewBag.Id = id;
            }

            return RedirectToAction("AllUserList");

        }
        public async Task<IActionResult> UserDetails(int id)
        {
            var userModel = await _userrepo.GetDetailsById(id);

            if (userModel == null)
            {
                return NotFound(); // Or handle the case when the user is not found
            }
            return View(userModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
