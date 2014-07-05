using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myOLX.Models
{
    public class AdminClass : IAdmin
    {
        public bool validate(Admin obj)
        {
            OLXEntities4 db = new OLXEntities4();

            bool res = false;
            var L2EQuery = from u in db.Admins
                           where u.adminName == obj.adminName
                           select u;
            foreach (Admin ad in L2EQuery)
            {
                if (ad.pwd.Equals(obj.pwd))
                {
                    res = true;
                }
            }
            db.Dispose();
            return res;
           
        }
    }
}