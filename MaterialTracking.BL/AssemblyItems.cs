using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class AssemblyItems : BaseClass
    {
        /// <summary>
        /// Returns all active Products
        /// </summary>
        /// <returns>Returns the list of all active Products</returns>
        public List<AssemblyItem> SelectAll()
        {
            return repository.Select<AssemblyItem>(c => c.IsActive);
        }

        /// <summary>
        /// Selects a single AssemblyItem by the AssemblyItem ID
        /// </summary>
        /// <param name="ProductID">the integer ID of the AssemblyItem</param>
        /// <returns>A single AssemblyItem entity</returns>
        public AssemblyItem SelectByID(int AssemblyItemID)
        {
            return repository.Select<AssemblyItem>(c => c.IsActive && c.AssemblyItemID == AssemblyItemID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the AssemblyItem record with applied changes
        /// </summary>
        /// <param name="AssemblyItem">The AssemblyItem record with the ProductID populated that is to be updated.</param>
        /// <returns>The AssemblyItem record back, unaltered.</returns>
        public AssemblyItem Update(AssemblyItem assemblyItem)
        {
            return repository.Update<AssemblyItem>(assemblyItem);
        }

        /// <summary>
        /// Inserts the AssemblyItem record into the database
        /// </summary>
        /// <param name="AssemblyItem">The new AssemblyItem record that is to be inserted into the database.</param>
        /// <returns>The inserted AssemblyItem record (complete with new ProductID)</returns>
        public AssemblyItem Insert(AssemblyItem assemblyItem)
        {
            return repository.Insert<AssemblyItem>(assemblyItem);
        }

        /// <summary>
        /// Changes the AssemblyItem status to not active
        /// </summary>
        /// <param name="AssemblyItem">The AssemblyItem record that is to be made inactive</param>
        public AssemblyItem SoftDelete(AssemblyItem assemblyItem)
        {
            assemblyItem.IsActive = false;
            return repository.Update<AssemblyItem>(assemblyItem);
        }

        /// <summary>
        /// Changes a AssemblyItem record of the specified AssemblyItem ID to be inactive
        /// </summary>
        /// <param name="ProductID">The integer ID of the AssemblyItem to make inactive </param>
        public AssemblyItem SoftDeleteByID(int assemblyItemID)
        {
            AssemblyItem AssemblyItem = SelectByID(assemblyItemID);
            return SoftDelete(AssemblyItem);
        }

    }
}
