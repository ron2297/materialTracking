using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class OrderDetails:BaseClass
    {
        public List<OrderDetail> SelectAll()
        {
            return repository.SelectWithAssociations<OrderDetail>(new List<string> { "Vendor","OrderRequest","Inventory","POOrderDetails" });
        }
        public OrderDetail SelectByID(int OrderDetailID)
        {
            return repository.Select<OrderDetail>(c => c.OrderDetailID == OrderDetailID).FirstOrDefault();
        }

        public OrderDetail Update(OrderDetail orderdetail)
        {
            return repository.Update<OrderDetail>(orderdetail);
        }

        public OrderDetail Insert(OrderDetail orderdetail)
        {
            return repository.Insert<OrderDetail>(orderdetail);
        }

        public OrderDetail SoftDelete(OrderDetail orderdetail)
        {

            return repository.Update<OrderDetail>(orderdetail);
        }

        public OrderDetail SoftDeleteByID(int OrderDetailID)
        {
            OrderDetail orderdetail = SelectByID(OrderDetailID);
            return SoftDelete(orderdetail);
        }
    }
}
