using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Login view ()

        //create register
        [HttpGet]       //sends and recieve data between the client and server using the web app
        public IActionResult Employee_Login()       //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

/*        [HttpPost]  //this pushes the below method, so it can override any other method
        [ValidateAntiForgeryToken]      //provides vailadation for any unsafe HTTP
        public IActionResult Employee_Login([Bind] EmployeeModel objReg)
        {
*//*            if (ModelState.IsValid)
            {
                return RedirectToAction("Create", "Login", new { LoginController = "" });
            }

            return View();*//*
        }*/

    }
}
