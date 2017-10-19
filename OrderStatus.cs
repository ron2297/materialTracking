using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class OrderStatus : BaseClass
    {
        
        /// <summary>
        /// Returns all active OrderStatus
        /// </summary>
        /// <returns>Returns the list of all active OrderStatus</returns>
        public List<OrderStatu> SelectAll()
        {
            return repository.Select<OrderStatu>();
        }
        
        /// <summary>
        /// Selects a single OrderStatu by the OrderStatu ID
        /// </summary>
        /// <param name="OrderStatuID">the integer ID of the OrderStatu</param>
        /// <returns>A single OrderStatu entity</returns>
        public OrderStatu SelectByID(int OrderStatusID)
        {
            return repository.Select<OrderStatu>(c => c.OrderStatusID == OrderStatusID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the OrderStatu record with applied changes
        /// </summary>
        /// <param name="OrderStatus">The OrderStatu record with the OrderStatuID populated that is to be updated.</param>
        /// <returns>The OrderStatu record back, unaltered.</returns>
        public OrderStatu Update(OrderStatu OrderStatus)
        {
            return repository.Update<OrderStatu>(OrderStatus);
        }

        /// <summary>
        /// Inserts the OrderStatu record into the database
        /// </summary>
        /// <param name="OrderStatus">The new OrderStatu record that is to be inserted into the database.</param>
        /// <returns>The inserted OrderStatu record (complete with new OrderStatuID)</returns>
        public OrderStatu Insert(OrderStatu OrderStatus)
        {
            return repository.Insert<OrderStatu>(OrderStatus);
        }
        /*
        /// <summary>
        /// Changes the OrderStatu status to not active
        /// </summary>
        /// <param name="OrderStatu">The OrderStatu record that is to be made inactive</param>
        public OrderStatu SoftDelete(OrderStatu OrderStatu)
        {
            OrderStatu.IsActive = false;
            return repository.Update<OrderStatu>(OrderStatu);
        }

        /// <summary>
        /// Changes a OrderStatu record of the specified OrderStatu ID to be inactive
        /// </summary>
        /// <param name="OrderStatuID">The integer ID of the OrderStatu to make inactive </param>
        public OrderStatu SoftDeleteByID(int OrderStatuID)
        {
            OrderStatu OrderStatu = SelectByID(OrderStatuID);
            return SoftDelete(OrderStatu);
        }
        */
    }
}
