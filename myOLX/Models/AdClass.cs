using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myOLX.Models
{
    public class AdClass : IAd
    {
        public void save(Ad obj)
        {
            using (OLXEntities4 db = new OLXEntities4())
            {
                db.Ads.Add(obj);
                db.SaveChanges();
            }
            //db.Dispose();
        }

        public List<Ad> search(Ad obj)
        {
            OLXEntities4 db = new OLXEntities4();
            var adss = db.Ads.ToList();
            var s = from ads in adss
                    where ads.title.Equals(obj.title) && ads.price<=obj.price
                    select ads;
           
            if(obj.title == "" && obj.price != 0)
            {
                s = from ads in adss
                        where ads.price <= obj.price
                        select ads;
            }
            else if (obj.title != "" && obj.price == 0)
            {
                s = from ads in adss
                    where ads.title == obj.title
                    select ads;
            }

            List<Ad> list = new List<Ad>();
            foreach (Ad ad in s)
            {
                    list.Add(ad);
                
            }

            return list;
        }


        public List<Ad> getAdds(Ad obj)
        {
            OLXEntities4 db = new OLXEntities4();
            var s = from ads in db.Ads
                    where ads.catName.Equals(obj.catName)
                    select ads;


            List<Ad> list = new List<Ad>();
            foreach (Ad ad in s)
            {
                    list.Add(ad);
            }

            return list;
        }

        public Ad getAdInfo(string title)
        {
            OLXEntities4 db = new OLXEntities4();
            var s = from ads in db.Ads
                    where ads.title.Equals(title)
                    select ads;
            List<Ad> list = new List<Ad>();
            foreach (Ad ad in s)
            {
                list.Add(ad);
            }
            return list[0];

        }
    }
}