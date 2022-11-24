using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XBCAD_WebApp.Controllers
{
    public class MessageSystem : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
