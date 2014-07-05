using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myOLX.Models;

namespace myOLX.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        ICategory repCat;
        public HomeController(ICategory v)
        {
            repCat = v;
        }

        public ActionResult Index()
        {
            List<String> cat = repCat.getCategoryList();
            ViewBag.categ = cat;
            return View();
        }
        
        public ActionResult contact()
        {
            return View();
        }

        public ActionResult about()
        {
            return View();
        }

        public ActionResult myaccount()
        {
            return View();
        }

        public ActionResult register()
        {
            return View();
        }

        public ActionResult specials()
        {
            return View();
        }

        public ActionResult details()
        {
            return View();
        }

        public ActionResult AdminAccount()
        {
            return View();
        }

    }
}
