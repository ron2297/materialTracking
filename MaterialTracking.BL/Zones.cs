using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class Zones : BaseClass
    {
        /// <summary>
        /// Returns all active Zones
        /// </summary>
        /// <returns>Returns the list of all active Zones</returns>
        public List<Zone> SelectAll()
        {
            return repository.Select<Zone>(c => c.IsActive);
        }

        /// <summary>
        /// Selects a single Zone by the Zone ID
        /// </summary>
        /// <param name="ZoneID">the integer ID of the Zone</param>
        /// <returns>A single Zone entity</returns>
        public Zone SelectByID(int ZoneID)
        {
            return repository.Select<Zone>(c => c.IsActive && c.ZoneID == ZoneID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the Zone record with applied changes
        /// </summary>
        /// <param name="zone">The Zone record with the ZoneID populated that is to be updated.</param>
        /// <returns>The Zone record back, unaltered.</returns>
        public Zone Update(Zone zone)
        {
            return repository.Update<Zone>(zone);
        }

        /// <summary>
        /// Inserts the Zone record into the database
        /// </summary>
        /// <param name="zone">The new Zone record that is to be inserted into the database.</param>
        /// <returns>The inserted Zone record (complete with new ZoneID)</returns>
        public Zone Insert(Zone zone)
        {
            return repository.Insert<Zone>(zone);
        }

        /// <summary>
        /// Changes the Zone status to not active
        /// </summary>
        /// <param name="zone">The Zone record that is to be made inactive</param>
        public Zone SoftDelete(Zone zone)
        {
            Zone.IsActive = false;
            return repository.Update<Zone>(zone);
        }

        /// <summary>
        /// Changes a Zone record of the specified Zone ID to be inactive
        /// </summary>
        /// <param name="ZoneID">The integer ID of the Zone to make inactive </param>
        public Zone SoftDeleteByID(int ZoneID)
        {
            Zone zone = SelectByID(ZoneID);
            return SoftDelete(zone);
        }

    }
}
