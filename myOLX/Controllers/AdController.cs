using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myOLX.Models;

namespace myOLX.Controllers
{

    public class AdController : Controller
    {
        //
        // GET: /Ad/
        IAd repo;
        ICategory repCat;
        public AdController(IAd u, ICategory v)
        {
            repo = u;
            repCat = v;
        }

        public ActionResult Index()
        {
            List<String> cat = repCat.getCategoryList();
            ViewBag.categ = cat;
            return View();
        }

        public ActionResult PostAd()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("myaccount", "Home");
            }
        }

        public ActionResult SearchAd()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("myaccount", "Home");
            }
        }

       [HttpGet]
        public ActionResult ViewAd()
        {
            if (Session["UserName"] != null)
            {
                Ad obj = new Ad();
                string inf = Request["info"];
                Ad ob = repo.getAdInfo(inf);
                ViewBag.x = ob;
                return View();
            }
            else
            {
                return RedirectToAction("myaccount", "Home");
            }
            
        }

        public ActionResult AddCat()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("AdminAccount", "Home");
            }
        }

        //Getting categoriess using JSON Result :O
        public JsonResult GetCategories()
        {
            List<String> cat = repCat.getCategoryList();
            return this.Json(cat, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult saveAd(Ad obj)
        {
          obj.catName = Request["catName"];
            //obj.catName = "Mobile";
            HttpPostedFileBase file = Request.Files[0];
            file.SaveAs(Server.MapPath(@"~\Images\" + file.FileName));
            obj.image = "../Images/" + file.FileName;
            repo.save(obj);
            //return RedirectToAction("/Home/index");
            return RedirectToAction("Index", "User");
        }

       //
       [HttpGet]
        public JsonResult search()
        {
            Ad obj= new Ad();
            obj.title = Request["title"];
            string temp = Request["price"];
            obj.price = int.Parse(Request["price"]);
            
            List<Ad>ls = repo.search(obj);
            //return RedirectToAction("/Home/index");
            //return RedirectToAction("Index", "Home");
            return this.Json(ls,
                  JsonRequestBehavior.AllowGet);
        }

       [HttpGet]
       public JsonResult getAds()
       {
           Ad obj = new Ad();
           obj.catName = Request["catName"];
         
           List<Ad> ls = repo.getAdds(obj);
           //return RedirectToAction("/Home/index");
           //return RedirectToAction("Index", "Home");
           return this.Json(ls,
                 JsonRequestBehavior.AllowGet);
       }

       [HttpPost]
       public ActionResult saveCat(Category obj)
       {
           repCat.addCat(obj);
           return RedirectToAction("Index", "Admin");
       }

    }
}
