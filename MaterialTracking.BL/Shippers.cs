using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class Shippers : BaseClass
    {
        /// <summary>
        /// Returns all active Shippers
        /// </summary>
        /// <returns>Returns the list of all active Shippers</returns>
        public List<Shipper> SelectAll()
        {
            return repository.Select<Shipper>(c => c.IsActive);
        }

        /// <summary>
        /// Selects a single Shipper by the shipper ID
        /// </summary>
        /// <param name="shipperID">the integer ID of the Shipper</param>
        /// <returns>A single Shipper entity</returns>
        public Shipper SelectByID(int shipperID)
        {
            return repository.Select<Shipper>(c => c.IsActive && c.ShipperID == shipperID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the shipper record with applied changes
        /// </summary>
        /// <param name="shipper">The shipper record with the shipperID populated that is to be updated.</param>
        /// <returns>The shipper record back, unaltered.</returns>
        public Shipper Update(Shipper shipper)
        {
            return repository.Update<Shipper>(shipper);
        }

        /// <summary>
        /// Inserts the shipper record into the database
        /// </summary>
        /// <param name="shipper">The new Shipper record that is to be inserted into the database.</param>
        /// <returns>The inserted Shipper record (complete with new ShipperID)</returns>
        public Shipper Insert(Shipper shipper)
        {
            return repository.Insert<Shipper>(shipper);
        }

        /// <summary>
        /// Changes the shipper status to not active
        /// </summary>
        /// <param name="shipper">The shipper record that is to be made inactive</param>
        public Shipper SoftDelete(Shipper shipper)
        {
            shipper.IsActive = false;
            return repository.Update<Shipper>(shipper);
        }

        /// <summary>
        /// Changes a shipper record of the specified shipper ID to be inactive
        /// </summary>
        /// <param name="shipperID">The integer ID of the shipper to make inactive </param>
        public Shipper SoftDeleteByID(int shipperID)
        {
            Shipper shipper = SelectByID(shipperID);
            return SoftDelete(shipper);
        }

    }
}
