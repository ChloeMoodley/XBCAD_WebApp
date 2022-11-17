using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class DealController : Controller
    {

        //Init of config, used to configure FireBase client with the path
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;

        public IActionResult EmpDealIndex()
        {
            //Get All Deals from the database
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


        //Controller methods to upload latest deals to the home page
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload([Bind] DealModel dealObj)
        {

            try
            {
                fbClient = new FireSharp.FirebaseClient(ifc);
                var data = dealObj;
                PushResponse response = fbClient.Push("WebDeals/", data);
                data.id = response.Result.name;
                SetResponse setResponse = fbClient.Set("WebDeals/" + data.id, data);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ModelState.AddModelError(string.Empty, "Added Succesfully");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Something went wrong!!");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return RedirectToAction("EmpDealIndex");

        }

        //Controller method to Delete a Deal
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        public ActionResult Delete(string id)
        {
            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Delete("WebDeals/" + id);
            return RedirectToAction("EmpDealIndex");
        }

    }
}
