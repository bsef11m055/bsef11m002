using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myOLX.Models
{
    public class CategoryClass : ICategory
    {
        public List<String> getCategoryList()
        {
            List<String> ls = new List<String>();
            OLXEntities4 db = new OLXEntities4();
            var s = from x in db.Categories
                    select x.catName;
            
            foreach(String name in s)
            {
                ls.Add(name);
            }
            db.Dispose();
            
            return ls;
        }


        public void addCat(Category obj)
        {
            using (OLXEntities4 db = new OLXEntities4())
            {
                db.Categories.Add(obj);
                db.SaveChanges();
            }
            //db.Dispose();
        }
    }
}