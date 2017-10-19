using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class ShippingItems : BaseClass
    {
        /// <summary>
        /// Returns all active Shippers
        /// </summary>
        /// <returns>Returns the list of all active Shippers</returns>
        public List<ShippingItem> SelectAll()
        {
            return repository.Select<ShippingItem>();
        }

        /// <summary>
        /// Selects a single ShippingItem by the shippingitem ID
        /// </summary>
        /// <param name="shippingorderID">the integer ID of the ShippingItem</param>
        /// <returns>A single ShippingItem entity</returns>
        public ShippingItem SelectByID(int shippingorderID)
        {
            return repository.Select<ShippingItem>(c => c.ShippingOrderID == shippingorderID).FirstOrDefault();

        }

        /// <summary>
        /// Updates the shippingitem record with applied changes
        /// </summary>
        /// <param name="shippingitem">The shippingitem record with the shippingorderID populated that is to be updated.</param>
        /// <returns>The shippingitem record back, unaltered.</returns>
        public ShippingItem Update(ShippingItem shippingitem)
        {
            return repository.Update<ShippingItem>(shippingitem);
        }

        /// <summary>
        /// Inserts the shippingitem record into the database
        /// </summary>
        /// <param name="shippingitem">The new ShippingItem record that is to be inserted into the database.</param>
        /// <returns>The inserted ShippingItem record (complete with new ShippingItemID)</returns>
        public ShippingItem Insert(ShippingItem shippingitem)
        {
            return repository.Insert<ShippingItem>(shippingitem);
        }

        /// <summary>
        /// Changes the shippingitem status to not active
        /// </summary>
        /// <param name="shippingitem">The shippingitem record that is to be made inactive</param>
        public ShippingItem SoftDelete(ShippingItem shippingitem)
        {
            //shippingitem.IsActive = false;
            return repository.Update<ShippingItem>(shippingitem);
        }

        /// <summary>
        /// Changes a shippingitem record of the specified shippingitem ID to be inactive
        /// </summary>
        /// <param name="shippingorderID">The integer ID of the shippingitem to make inactive </param>
        public ShippingItem SoftDeleteByID(int shippingorderID)
        {
            ShippingItem shippingitem = SelectByID(shippingorderID);
            return SoftDelete(shippingitem);
        }

    }
}
