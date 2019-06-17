using LoginOWIN.Repository;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LoginOWIN.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private LoginContext db = new LoginContext();

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string username, string returnUrl)
        {

            //var user = _userService.GetByEmail(model.Email);
            var user = db.Usuario.FirstOrDefault(u => u.Usuario1 == username);

            //check username and password from database, naive checking: 
            //password should be in SHA
            if (user != null)
            {
                var claims = new[] {
                new Claim(ClaimTypes.Role, user.Cargo),
                new Claim(ClaimTypes.Name, user.Usuario1),
                // can add more claims
            };

                var identity = new ClaimsIdentity(claims, "ApplicationCookie");

                // Add roles into claims
                //var roles = _roleService.GetByUserId(user.Id);
                //var roles = _roleService.GetByUserId(user.Id);
                //if (roles.Any())
                //{
                //    var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r.Name));
                //    identity.AddClaims(roleClaims);
                //}

                var context = Request.GetOwinContext();
                var authManager = context.Authentication;

                authManager.SignIn(new AuthenticationProperties
                { IsPersistent = false }, identity);

                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }
    }
}
