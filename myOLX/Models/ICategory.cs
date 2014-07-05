using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOLX.Models
{
    public interface ICategory
    {
        List<String> getCategoryList();
        void addCat(Category obj);
    }
}
