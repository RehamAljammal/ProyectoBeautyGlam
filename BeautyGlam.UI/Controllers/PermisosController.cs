using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyGlam.UI.Controllers
{
    public class PermisosController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(FormCollection form) => RedirectToAction("Index");

        public ActionResult Edit(int id) => View();

        [HttpPost]
        public ActionResult Edit(int id, FormCollection form) => RedirectToAction("Index");
    }
}
