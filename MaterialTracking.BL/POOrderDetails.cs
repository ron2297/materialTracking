using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class POOrderDetails : BaseClass
    {
        public List<POOrderDetail> SelectAll()
        {
            return repository.Select<POOrderDetail>();
        }

        public POOrderDetail SelectByID(int POID)
        {
            return repository.Select<POOrderDetail>(c => c.POOrderDetailID == POID).FirstOrDefault();
        }

        public POOrderDetail Update(POOrderDetail pO)
        {
            return repository.Update<POOrderDetail>(pO);
        }

        public POOrderDetail Insert(POOrderDetail pO)
        {
            return repository.Insert<POOrderDetail>(pO);
        }

        public POOrderDetail SoftDeleteByID(int pOID)
        {
            POOrderDetail pO = SelectByID(pOID);
            return repository.Update<POOrderDetail>(pO);
        }

    }
}
