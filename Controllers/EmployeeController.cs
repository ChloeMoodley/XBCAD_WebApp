using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
  
        //Init of config, used to configure FireBase client with the path
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;

        //create Login
        [HttpGet] //sends and recieve data between the client and server using the web app
        public IActionResult Employee_Login()  //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Employee_Login([Bind] EmployeeModel EmpObj)
        //{
        //    fbClient = new FireSharp.FirebaseClient(ifc);
        //    FirebaseResponse response = fbClient.Get("users");
        //    dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
        //    var list = new List<EmployeeModel>();
        //    foreach(var item in list)
        //    {
        //        if (EmpObj.Employee_Email.Equals(data.email))
        //        {
                    
        //        }

        //    }

        //    return View();
        //}


        [HttpGet] //sends and recieve data between the client and server using the web app
        public IActionResult Employee_HomePage() //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

    }
}
