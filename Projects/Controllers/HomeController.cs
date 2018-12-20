using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projects.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }

        [Authorize(Roles ="Administrateur")]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [Authorize(Roles = "Secretaire de Production")]
        public ActionResult SecretaireIndex()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }


    }
}