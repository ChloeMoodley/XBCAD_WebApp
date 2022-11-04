using Microsoft.AspNetCore.Mvc;
using XBCAD_WebApp.Models;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Extensions;
using FireSharp;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace XBCAD_WebApp.Controllers
{
    public class FAQController : Controller
    {
        //Init of config, used to configure FireBase client with the path
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;

        //Index view for everyone to access
        public ActionResult Index()
        {
            //Get All FAQ's
            List<FAQModel> FAQList = new List<FAQModel>();

            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("FAQ's");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            if (data != null)
            {
                foreach (var item in data)
                {
                    FAQList.Add(JsonConvert.DeserializeObject<FAQModel>(((JProperty)item).Value.ToString()));
                }
            }

            return View(FAQList);
        }

        //Index view only for employees to access (contains CRUD operations on FAQ's).
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        public ActionResult EmpFAQIndex()
        {
            //Get All FAQ's
            List<FAQModel> FAQList = new List<FAQModel>();

            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("FAQ's");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            if (data != null)
            {
                foreach (var item in data)
                {
                    FAQList.Add(JsonConvert.DeserializeObject<FAQModel>(((JProperty)item).Value.ToString()));
                }
            }

            return View(FAQList);
        }

        //Controller methods to create a new FAQ and Answer to that FAQ.
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] FAQModel faqObj)
        {

            try
            {
                fbClient = new FireSharp.FirebaseClient(ifc);
                var data = faqObj;
                PushResponse response = fbClient.Push("FAQ's/", data);
                data.id = response.Result.name;
                SetResponse setResponse = fbClient.Set("FAQ's/" + data.id, data);

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

            return RedirectToAction("EmpFAQIndex");

        }

        //Controller methods to Edit an FAQ and Answer to that FAQ.
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        [HttpGet]
        public ActionResult Edit(string id)
        {
            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("FAQ's/" + id);
            FAQModel data = JsonConvert.DeserializeObject<FAQModel>(response.Body);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(FAQModel faq)
        {
            fbClient = new FireSharp.FirebaseClient(ifc);
            SetResponse response = fbClient.Set("FAQ's/" + faq.id, faq);
            return RedirectToAction("EmpFAQIndex");
        }

        //Controller method to Delete an FAQ
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        public ActionResult Delete(string id)
        {
            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Delete("FAQ's/" + id);
            return RedirectToAction("EmpFAQIndex");
        }

    }
}
