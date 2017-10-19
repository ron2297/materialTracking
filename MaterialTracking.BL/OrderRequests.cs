using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class OrderRequests : BaseClass
    {
        public List<OrderRequest> SelectAll()
        {
            ///Should the select all only select active orders / orders that don't contain a 8 / 10 / 12
            return repository.Select<OrderRequest>();
        }

        public OrderRequest SelectByID(int orderRequestID)
        {
            return repository.Select<OrderRequest>(c => c.OrderRequestID == orderRequestID).FirstOrDefault();
        }

        public OrderRequest Update(OrderRequest orderRequest)
        {
            return repository.Update<OrderRequest>(orderRequest);
        }

        public OrderRequest Insert(OrderRequest orderRequest)
        {
            return repository.Insert<OrderRequest>(orderRequest);
        }

/// <summary>
/// Soft delete cancels the order
/// </summary>
/// <param name="orderRequest"></param>
/// <returns></returns>
        public OrderRequest SoftDelete(OrderRequest orderRequest)
        {
            orderRequest.OrderStatusID = 12;
            return repository.Update<OrderRequest>(orderRequest);
        }

        public OrderRequest SoftDeleteByID(int orderRequestID)
        {
            OrderRequest orderRequest = SelectByID(orderRequestID);
            return SoftDelete(orderRequest);
        }

    }
}
