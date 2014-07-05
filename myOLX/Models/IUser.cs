using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOLX.Models
{
    public interface IUser
    {
        bool validate(User obj);
        void save(User obj);
        bool checkUname(string uname);
    }
}
