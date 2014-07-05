using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myOLX.Models;

namespace myOLX.Controllers
{
       
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        IAdmin repo;
        ICategory repCat;
        public AdminController(IAdmin u, ICategory v)
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
                return RedirectToAction("AdminAccount", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult validate(Admin obj)
        {
            if (ModelState.IsValid)
            {
                if (repo.validate(obj))
                {
                    Session["UserName"] = obj.adminName;
                    return RedirectToAction("Index");
                }
                else
                {
                    String err = "Either userName or Password is Wrong ..Try Again";
                    ViewBag.x = err;
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
