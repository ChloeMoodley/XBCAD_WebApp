using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using XBCAD_WebApp.Models;
using System;

using PagedList;
using PagedList.Mvc;
using XBCAD_WebApp.Models.ViewModels;

namespace XBCAD_WebApp.Controllers
{
    public class MessagesController : Controller
    {

        public IActionResult Index()
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


            return View();
        }

    }
}

