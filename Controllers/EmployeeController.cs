using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class EmployeeController : Controller
    {

        //create Login
        [HttpGet] //sends and recieve data between the client and server using the web app
        public IActionResult Employee_Login()  //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }


        [HttpGet] //sends and recieve data between the client and server using the web app
        public IActionResult Employee_HomePage() //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

    }
}
