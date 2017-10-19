using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class ShippingOrders : BaseClass
    {
        /// <summary>
        /// Returns all active Shippers
        /// </summary>
        /// <returns>Returns the list of all active Shippers</returns>
        public List<ShippingOrder> SelectAll()
        {
            return repository.Select<ShippingOrder>();
        }

        /// <summary>
        /// Selects a single ShippingOrder by the shippingorder ID
        /// </summary>
        /// <param name="shipperID">the integer ID of the ShippingOrder</param>
        /// <returns>A single ShippingOrder entity</returns>
        public ShippingOrder SelectByID(int shipperID)
        {
            return repository.Select<ShippingOrder>(c => c.ShipperID == shipperID).FirstOrDefault();

        }

        /// <summary>
        /// Updates the shippingorder record with applied changes
        /// </summary>
        /// <param name="shippingorder">The shippingorder record with the shipperID populated that is to be updated.</param>
        /// <returns>The shippingorder record back, unaltered.</returns>
        public ShippingOrder Update(ShippingOrder shippingorder)
        {
            return repository.Update<ShippingOrder>(shippingorder);
        }

        /// <summary>
        /// Inserts the shippingorder record into the database
        /// </summary>
        /// <param name="shippingorder">The new ShippingOrder record that is to be inserted into the database.</param>
        /// <returns>The inserted ShippingOrder record (complete with new ShipperID)</returns>
        public ShippingOrder Insert(ShippingOrder shippingorder)
        {
            return repository.Insert<ShippingOrder>(shippingorder);
        }

        /// <summary>
        /// Changes the shippingorder status to not active
        /// </summary>
        /// <param name="shippingorder">The shippingorder record that is to be made inactive</param>
        public ShippingOrder SoftDelete(ShippingOrder shippingorder)
        {
            //shippingorder.IsActive = false;
            return repository.Update<ShippingOrder>(shippingorder);
        }

        /// <summary>
        /// Changes a shippingorder record of the specified shippingorder ID to be inactive
        /// </summary>
        /// <param name="shipperID">The integer ID of the shippingorder to make inactive </param>
        public ShippingOrder SoftDeleteByID(int shipperID)
        {
            ShippingOrder shippingorder = SelectByID(shipperID);
            return SoftDelete(shippingorder);
        }

    }
}
