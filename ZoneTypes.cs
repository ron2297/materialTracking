using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class ZoneTypes : BaseClass
    {
        /// <summary>
        /// Returns all active ZoneTypes
        /// </summary>
        /// <returns>Returns the list of all active ZoneTypes</returns>
        public List<ZoneType> SelectAll()
        {
            return repository.Select<ZoneType>(c => c.IsActive);
        }

        /// <summary>
        /// Selects a single ZoneType by the ZoneType ID
        /// </summary>
        /// <param name="ZoneTypeID">the integer ID of the ZoneType</param>
        /// <returns>A single ZoneType entity</returns>
        public ZoneType SelectByID(int ZoneTypeID)
        {
            return repository.Select<ZoneType>(c => c.IsActive && c.ZoneTypeID == ZoneTypeID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the ZoneType record with applied changes
        /// </summary>
        /// <param name="ZoneType">The ZoneType record with the ZoneTypeID populated that is to be updated.</param>
        /// <returns>The ZoneType record back, unaltered.</returns>
        public ZoneType Update(ZoneType ZoneType)
        {
            return repository.Update<ZoneType>(ZoneType);
        }

        /// <summary>
        /// Inserts the ZoneType record into the database
        /// </summary>
        /// <param name="ZoneType">The new ZoneType record that is to be inserted into the database.</param>
        /// <returns>The inserted ZoneType record (complete with new ZoneTypeID)</returns>
        public ZoneType Insert(ZoneType ZoneType)
        {
            return repository.Insert<ZoneType>(ZoneType);
        }

        /// <summary>
        /// Changes the ZoneType status to not active
        /// </summary>
        /// <param name="ZoneType">The ZoneType record that is to be made inactive</param>
        public ZoneType SoftDelete(ZoneType ZoneType)
        {
            ZoneType.IsActive = false;
            return repository.Update<ZoneType>(ZoneType);
        }

        /// <summary>
        /// Changes a ZoneType record of the specified ZoneType ID to be inactive
        /// </summary>
        /// <param name="ZoneTypeID">The integer ID of the ZoneType to make inactive </param>
        public ZoneType SoftDeleteByID(int ZoneTypeID)
        {
            ZoneType ZoneType = SelectByID(ZoneTypeID);
            return SoftDelete(ZoneType);
        }

    }
}
