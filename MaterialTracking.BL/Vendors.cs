using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class Vendors : BaseClass
    {
        /// <summary>
        /// Returns all active Vendors
        /// </summary>
        /// <returns>Returns the list of all active Vendors</returns>
        public List<Vendor> SelectAll()
        {
            return repository.Select<Vendor>(c => c.IsActive);
        }

        /// <summary>
        /// Selects a single Vendor by the vendor ID
        /// </summary>
        /// <param name="vendorID">the integer ID of the Vendor</param>
        /// <returns>A single Vendor entity</returns>
        public Vendor SelectByID(int vendorID)
        {
            return repository.Select<Vendor>(c => c.IsActive && c.VendorID == vendorID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the vendor record with applied changes
        /// </summary>
        /// <param name="vendor">The vendor record with the vendorID populated that is to be updated.</param>
        /// <returns>The vendor record back, unaltered.</returns>
        public Vendor Update(Vendor vendor)
        {
            return repository.Update<Vendor>(vendor);
        }

        /// <summary>
        /// Inserts the vendor record into the database
        /// </summary>
        /// <param name="vendor">The new Vendor record that is to be inserted into the database.</param>
        /// <returns>The inserted Vendor record (complete with new VendorID)</returns>
        public Vendor Insert(Vendor vendor)
        {
            return repository.Insert<Vendor>(vendor);
        }

        /// <summary>
        /// Changes the vendor status to not active
        /// </summary>
        /// <param name="vendor">The vendor record that is to be made inactive</param>
        public Vendor SoftDelete(Vendor vendor)
        {
            vendor.IsActive = false;
            return repository.Update<Vendor>(vendor);
        }

        /// <summary>
        /// Changes a vendor record of the specified vendor ID to be inactive
        /// </summary>
        /// <param name="vendorID">The integer ID of the vendor to make inactive </param>
        public Vendor SoftDeleteByID(int vendorID)
        {
            Vendor vendor = SelectByID(vendorID);
            return SoftDelete(vendor);
        }

    }
}
