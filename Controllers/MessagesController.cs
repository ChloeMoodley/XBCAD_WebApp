﻿using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using XBCAD_WebApp.Models;
using System;
using FireSharp.Config;
using FireSharp.Response;

using PagedList;
using PagedList.Mvc;
using XBCAD_WebApp.Models.ViewModels;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using FireSharp.Interfaces;


namespace XBCAD_WebApp.Controllers
{
    public class MessagesController : Controller
    {
        //Init of config, used to configure FireBase client with the path
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            //AuthSecret = "2yHHLIYJd7mITvNBUV7cq3HVc9ItUv4nkmABbI4m",
            BasePath = "https://skytell-fbdb-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient fbClient;

        [HttpGet]
        public IActionResult ViewMessages()
        {
            //Get All Deals from the database
            List<Message> MessageList = new List<Message>();

            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Get("WebMessages/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);

            if (data != null)
            {
                foreach (var item in data)
                {
                    MessageList.Add(JsonConvert.DeserializeObject<Message>(((JProperty)item).Value.ToString()));
                }
            }

            return View(MessageList);
        }

/*        public IActionResult Index()
        {
            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //MessageReplyViewModel vm = new MessageReplyViewModel();
            //var count = vm.Messages.Count();

            //decimal totalPages = count / (decimal)pageSize;
            //ViewBag.TotalPages = Math.Ceiling(totalPages);
            //vm.Messages = vm.Messages
            //                           .OrderBy(x => x.DatePosted).ToPagedList(pageNumber, pageSize);
            //ViewBag.MessagesInOnePage = vm.Messages;
            //ViewBag.PageNumber = pageNumber;

            //if (Id != null)
            //{

            //    var replies = vm.Replies.Where(x => x.MessageId == Id.Value).OrderByDescending(x => x.ReplyDateTime).ToList();
            //    if (replies != null)
            //    {
            //        foreach (var rep in replies)
            //        {
            //            MessageReplyViewModel.MessageReply reply = new MessageReplyViewModel.MessageReply();
            //            reply.MessageId = rep.MessageId;
            //            reply.Id = rep.Id;
            //            reply.ReplyMessage = rep.ReplyMessage;
            //            reply.ReplyDateTime = rep.ReplyDateTime;
            //            reply.MessageDetails = vm.Messages.Where(x => x.Id == rep.MessageId).Select(s => s.MessageToPost).FirstOrDefault();
            //            reply.ReplyFrom = rep.ReplyFrom;
            //            vm.Replies.Add(reply);
            //        }

            //    }
            //    else
            //    {
            //        vm.Replies.Add(null);
            //    }


            //    ViewBag.MessageId = Id.Value;


            return View();*/

        //}
        [HttpGet]
        public IActionResult UploadMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadMessage([Bind] Message faqObj)
        {
            try
            {
                fbClient = new FireSharp.FirebaseClient(ifc);
                var data = faqObj;
                PushResponse response = fbClient.Push("WebMessages/", data);
                data.Id = response.Result.name;
                SetResponse setResponse = fbClient.Set("WebMessages/" + data.Id, data);

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

            //return RedirectToAction("EmpDealIndex");
            return View();
        }

        //Controller method to Delete a Deal
        //Referencing: https://www.freecodespot.com/blog/dotnet-core-crud-with-firebase-database/
        public ActionResult Delete(string id)
        {
            fbClient = new FireSharp.FirebaseClient(ifc);
            FirebaseResponse response = fbClient.Delete("WebMessages/" + id);
            //return RedirectToAction("Employee_HomePage", "Employee");
            return View();
        }

    }
}

