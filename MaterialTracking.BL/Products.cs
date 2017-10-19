using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class Products : BaseClass
    {
        /// <summary>
        /// Returns all active Products
        /// </summary>
        /// <returns>Returns the list of all active Products</returns>
        public List<Product> SelectAll()
        {
            return repository.Select<Product>(c => c.IsActive);
        }

        /// <summary>
        /// Selects a single Product by the Product ID
        /// </summary>
        /// <param name="ProductID">the integer ID of the Product</param>
        /// <returns>A single Product entity</returns>
        public Product SelectByID(int ProductID)
        {
            return repository.Select<Product>(c => c.IsActive && c.ProductID == ProductID).FirstOrDefault();
        }

        /// <summary>
        /// Updates the Product record with applied changes
        /// </summary>
        /// <param name="Product">The Product record with the ProductID populated that is to be updated.</param>
        /// <returns>The Product record back, unaltered.</returns>
        public Product Update(Product Product)
        {
            return repository.Update<Product>(Product);
        }

        /// <summary>
        /// Inserts the Product record into the database
        /// </summary>
        /// <param name="Product">The new Product record that is to be inserted into the database.</param>
        /// <returns>The inserted Product record (complete with new ProductID)</returns>
        public Product Insert(Product Product)
        {
            return repository.Insert<Product>(Product);
        }

        /// <summary>
        /// Changes the Product status to not active
        /// </summary>
        /// <param name="Product">The Product record that is to be made inactive</param>
        public Product SoftDelete(Product Product)
        {
            Product.IsActive = false;
            return repository.Update<Product>(Product);
        }

        /// <summary>
        /// Changes a Product record of the specified Product ID to be inactive
        /// </summary>
        /// <param name="ProductID">The integer ID of the Product to make inactive </param>
        public Product SoftDeleteByID(int ProductID)
        {
            Product Product = SelectByID(ProductID);
            return SoftDelete(Product);
        }

    }
}
