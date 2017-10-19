using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class POOrders : BaseClass
    {
        public List<POOrder> SelectAll()
        {
            return repository.Select<POOrder>();
        }

        public POOrder SelectByID(int POI)
        {
            return repository.Select<POOrder>(c => c.POOrderID == POI).FirstOrDefault();
        }

        public POOrder Update(POOrder pO)
        {
            return repository.Update<POOrder>(pO);
        }

        public POOrder Insert(POOrder pO)
        {
            return repository.Insert<POOrder>(pO);
        }

        public POOrder SoftDeleteByID(int pOI)
        {
            POOrder pO = SelectByID(pOI);
            return repository.Update<POOrder>(pO);
        }

    }
}
