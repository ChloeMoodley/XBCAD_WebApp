using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XBCAD_WebApp.Models;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Extensions;
using FireSharp;

namespace XBCAD_WebApp.Controllers
{
    public class HomeController : Controller
    {

        
        //Init of config, used to configure FireBase client with the path
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                //creates new DB reference (fbClient), adding the desired DB Node to the basepath of the reference config
                IFirebaseConfig testCfg = ifc;
                testCfg.BasePath += "Placeholder-BasicWriteTest";
                fbClient = new FirebaseClient(testCfg);

                //Writes to DB; first param = path of write; second param = data written, in this case a FAQModel object
                fbClient.SetAsync("Test2", new FAQModel("Does this work?", "Maybe?"));

            }
            catch (Exception e)
            {
                
                
            }

            return View();
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