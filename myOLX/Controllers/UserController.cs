using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myOLX.Models;

namespace myOLX.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        IUser repo;
        ICategory repCat;
        public UserController(IUser u,ICategory v)
        {
            repCat = v;
            repo = u;
        }

        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                List<String> cat = repCat.getCategoryList();
                ViewBag.categ = cat;
                return View();
            }
            else
            {
                return RedirectToAction("myaccount", "Home");
            }
        }

        [HttpPost]
        public ActionResult validate(User obj)
        {
            if (ModelState.IsValid)
            {
                if (repo.validate(obj))
                {
                    Session["UserName"] = obj.userName;
                    return RedirectToAction("/Index");
                    //return View("/Index");
                }
                else
                {
                    String err = "Either userName or Password is Wrong ..Try Again";
                    ViewBag.x = err;
                    return RedirectToAction("myaccount", "Home");
                    //return View("myaccount", "Home");
                    //return VIew


                }
            }
            return RedirectToAction("myaccount", "Home");
        }

        [HttpPost]
        public ActionResult save(User obj)
        {
            if (ModelState.IsValid)
            {
                repo.save(obj);
              
            }
            return RedirectToAction("index","Home");
        }

        public JsonResult CheckUserName()
        {
            string userName = Request["u"];
            bool flag = repo.checkUname(userName);
            return this.Json(flag,
                  JsonRequestBehavior.AllowGet);
        }
    }
}
