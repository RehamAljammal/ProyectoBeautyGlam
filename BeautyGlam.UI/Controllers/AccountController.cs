using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(FormCollection form) => RedirectToAction("Index", "Home");

        public ActionResult Register() => View();

        [HttpPost]
        public ActionResult Register(FormCollection form) => RedirectToAction("Login");

        public ActionResult Recuperar() => View();

        [HttpPost]
        public ActionResult Recuperar(FormCollection form)
        {
            return RedirectToAction("Login");
        }
    }
}
