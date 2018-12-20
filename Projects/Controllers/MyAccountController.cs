using Projects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projects.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login l, string ReturnUrl="")
        {
            //using (DBEntities db = new DBEntities())
            //{
            //    var user = db.Users.Where(a=>a.Username.Equals(l.Username) && a.Password.Equals(l.Password)).FirstOrDefault();
            //    if(user !=null)
            //    {
            //        FormsAuthentication.SetAuthCookie(user.Username, l.RememberMe);
            //        if(Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        else
            //        {
            //            return RedirectToAction("MyProfile","Home");
            //        }
            //    }


            //}



            if(ModelState.IsValid)
            {
                var isValidUser = Membership.ValidateUser(l.Username, l.Password);
                if(isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(l.Username, l.RememberMe);
                    if(Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Home");
                    }
                }
            }



            ModelState.Remove("Password");
                return View();
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}