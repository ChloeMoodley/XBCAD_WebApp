using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XBCAD_WebApp.Models;
using Microsoft.AspNetCore.Http;
using Firebase.Auth;
using FireSharp.Config;
using FirebaseConfig = Firebase.Auth.FirebaseConfig;

namespace XBCAD_WebApp.Controllers
{
    public class LoginController : Controller
    {
        FirebaseAuthProvider auth;
        public LoginController()
        {
            auth = new FirebaseAuthProvider(
                            new FirebaseConfig("AIzaSyBQgTUBNFnfsSRRU2er5kRpVxzIeGBCxlI"));
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginModel)
        {
            //log in the user
            var fbAuthLink = await auth.SignInWithEmailAndPasswordAsync(loginModel.Email, loginModel.Password);
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
        }



    }
}

