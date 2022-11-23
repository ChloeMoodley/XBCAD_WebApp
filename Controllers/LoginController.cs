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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace XBCAD_WebApp.Controllers
{
    public class LoginController : Controller
    {

        private static string apiKey = "AIzaSyBQgTUBNFnfsSRRU2er5kRpVxzIeGBCxlI";

/*        FirebaseAuthProvider auth;
        public LoginController()
        {
            auth = new FirebaseAuthProvider(
                            new FirebaseConfig("AIzaSyBQgTUBNFnfsSRRU2er5kRpVxzIeGBCxlI"));
        }*/

        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn(string returnURL)
        {
            try
            {
                //supposed to be Request.IsAuthenicated
                if (Request.IsHttps)
                {
                    return RedirectToRoute(returnURL);
                }
            }

            catch (Exception ex)
            { 
                Console.WriteLine(ex);  
            }

            return View();
        }
         
        public async Task<ActionResult> LogIn (LoginViewModel model, string returnURL)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                    string token = a.FirebaseToken;
                    var user = a.User;
                    if (token != "")
                    {
                        //SignInUser(user.Email, token, false);
                        return Redirect(returnURL);
                    }

                    else
                    {
                        ModelState.AddModelError(string.Empty, "Error username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                
            }
            return View();  
        }

/*        public void SignInUser(string email, string token, bool isPersisted)
        {
            var claims = new List<Claim>();

            try
            {
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenicationTypes.ApplicationCookie);
            }
            catch (Exception)
            {

                throw;
            }
        }*/

/*        [HttpPost]
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
        }*/



    }
}

