using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
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
        IFirebaseConfig ifc = new FireSharp.Config.FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;
        /*        //Init of config, used to configure FireBase client with the path
                //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
                IFirebaseConfig ifc = new FirebaseConfig()
                {
                    //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
                    BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
                };
                IFirebaseClient fbClient;*/

        FirebaseAuthProvider auth;
        public EmployeeController()
        {
            auth = new FirebaseAuthProvider(
                            new Firebase.Auth.FirebaseConfig("AIzaSyBQgTUBNFnfsSRRU2er5kRpVxzIeGBCxlI"));
        }

        //create Login
        [HttpGet] //sends and recieve data between the client and server using the web app
        public IActionResult Employee_Login()  //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Employee_Login(EmployeeModel EmpObj)
        {

            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("Users/");

            //log in the user
            var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(EmpObj.emp_Email, EmpObj.emp_Password);
                string token = fbAuthLink.FirebaseToken;
                //saving the token in a session variable
                if (token != null)
                {
                    HttpContext.Session.SetString("_UserToken", token);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            /*fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("Users/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            if (data != null)
            {
                foreach (var item in data)
                {
                    if (EmpObj.emp_Email.Equals(item))
                    {
                        return RedirectToAction("Employee_HomePage");
                    }
                    else
                    {
                        return RedirectToAction("Employee_Login");
                    }
                }
            }*/
        }


        [HttpGet] //sends and recieve data between the client and server using the web app
        public IActionResult Employee_HomePage() //makes the html code visible on the web pages as it returns the view
        {
            return View();
        }

       /* public async Task<ActionResult> Employee_HomePage()
        {
            //Simulate test user data and login timestamp
            var userId = "12345";
            var currentLoginTime = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");

            //Save non identifying data to Firebase
            var currentUserLogin = new LoginViewModel() { TimestampUtc = currentLoginTime };
            var firebaseClient = new FirebaseClient("yourFirebaseProjectUrl");
            var result = await firebaseClient
              .Child("Users/" + userId + "/Logins")
              .PostAsync(currentUserLogin);

            //Retrieve data from Firebase
            var dbLogins = await firebaseClient
              .Child("Users")
              .Child(userId)
              .Child("Logins")
              .OnceAsync<LoginViewModel>();

            var timestampList = new List<DateTime>();

            //Convert JSON data to original datatype
            foreach (var login in dbLogins)
            {
                timestampList.Add(Convert.ToDateTime(login.Object.TimestampUtc).ToLocalTime());
            }

            //Pass data to the view
            ViewBag.CurrentUser = userId;
            ViewBag.Logins = timestampList.OrderByDescending(x => x);
            return View();
        }*/

    }
}
