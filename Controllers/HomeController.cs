using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Init of config, used to configure FireBase client with the path
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;

        public IActionResult Index()
        {
            //Get All Deals from the database and display them on the home page.
            //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
            List<DealModel> DealList = new List<DealModel>();

            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("WebDeals");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            if (data != null)
            {
                foreach (var item in data)
                {
                    DealList.Add(JsonConvert.DeserializeObject<DealModel>(((JProperty)item).Value.ToString()));
                }
            }

            return View(DealList);
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