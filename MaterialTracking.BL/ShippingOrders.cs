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
        /// Selects a single ShippingOrder by the shippingorders ID
        /// </summary>
        /// <param name="shippingorderID">the integer ID of the ShippingOrder</param>
        /// <returns>A single ShippingOrder entity</returns>
        public ShippingOrder SelectByID(int shippingorderID)
        {
            return repository.Select<ShippingOrder>(c => c.ShippingOrderID == shippingorderID).FirstOrDefault();

        }

        /// <summary>
        /// Updates the shippingorders record with applied changes
        /// </summary>
        /// <param name="shippingorders">The shippingorders record with the shippingorderID populated that is to be updated.</param>
        /// <returns>The shippingorders record back, unaltered.</returns>
        public ShippingOrder Update(ShippingOrder shippingorders)
        {
            return repository.Update<ShippingOrder>(shippingorders);

        }

        /// <summary>
        /// Inserts the shippingorders record into the database
        /// </summary>
        /// <param name="shippingorders">The new ShippingOrder record that is to be inserted into the database.</param>
        /// <returns>The inserted ShippingOrder record (complete with new ShipperID)</returns>
        public ShippingOrder Insert(ShippingOrder shippingorders)
        {
            return repository.Insert<ShippingOrder>(shippingorders);
        }

        /// <summary>
        /// Changes the shippingorders status to not active
        /// </summary>
        /// <param name="shippingorders">The shippingorders record that is to be made inactive</param>
        public ShippingOrder SoftDelete(ShippingOrder shippingorders)
        {
            //shippingorders.IsActive = false;
            return repository.Update<ShippingOrder>(shippingorders);
        }

        /// <summary>
        /// Changes a shippingorders record of the specified shippingorders ID to be inactive
        /// </summary>
        /// <param name="shippingorderID">The integer ID of the shippingorders to make inactive </param>
        public ShippingOrder SoftDeleteByID(int shippingorderID)
        {
            ShippingOrder shippingorders = SelectByID(shippingorderID);
            return SoftDelete(shippingorders);
        }

    }
}
