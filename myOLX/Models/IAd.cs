using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myOLX.Models
{
    public interface IAd
    {
        void save(Ad obj);
        List<Ad> search(Ad obj);
        List<Ad> getAdds(Ad obj);
        Ad getAdInfo(string title);
    }
}
