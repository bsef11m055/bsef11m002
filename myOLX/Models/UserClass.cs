using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myOLX.Models
{
    public class UserClass : IUser
    {
        public bool validate(User obj)
        {
           
            OLXEntities4 db = new OLXEntities4();
           

            bool res = false;
            var L2EQuery = from u in db.Users
                           where u.userName == obj.userName
                           select u;
            foreach (User use in L2EQuery)
            {
                if (use.pwd.Equals(obj.pwd))
                {
                    res = true;
                }
            }
            db.Dispose();
            return res;
            
        }

        public void save(User obj)
        {
            using (OLXEntities4 db = new OLXEntities4())
            {
                db.Users.Add(obj);
                db.SaveChanges(); 
            }
            //db.Dispose();
        }

        public bool checkUname(string uname)
        {
            OLXEntities4 db = new OLXEntities4();
            bool res = false;
            var L2EQuery = from u in db.Users
                           where u.userName == uname
                           select u;
            List<User> ls = new List<User>();
            foreach (User use in L2EQuery)
            {
                ls.Add(use);
            }
            if (ls.Count >= 1)
            {
                res = true;
            }
            db.Dispose();
            return res;
        }
    }
}