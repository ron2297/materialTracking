using System;
using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    class AssemblyItemProducts:BaseClass 
    {
        
        public List<AssemblyItemProduct> SelectAll()
        {
            return repository.SelectWithAssociations<AssemblyItemProduct>(new List<string> { "Product"});
        }

        
        public AssemblyItemProduct SelectByID(int ProductID)
        {
            return repository.Select<AssemblyItemProduct>(c => c.IsActive && c.ProductID == ProductID).FirstOrDefault();
        }

       
        public AssemblyItemProduct Update(AssemblyItemProduct AssemblyItemProduct)
        {
            return repository.Update<AssemblyItemProduct>(AssemblyItemProduct);
        }

        
        public AssemblyItemProduct Insert(AssemblyItemProduct AssemblyItemProduct)
        {
            return repository.Insert<AssemblyItemProduct>(AssemblyItemProduct);
        }

        
        public AssemblyItemProduct SoftDelete(AssemblyItemProduct AssemblyItemProduct)
        {
            AssemblyItemProduct.IsActive = false;
            return repository.Update<AssemblyItemProduct>(AssemblyItemProduct);
        }

        public AssemblyItemProduct SoftDeleteByID(int ProductID)
        {
            AssemblyItemProduct AssemblyItemProduct = SelectByID(ProductID);
            return SoftDelete(AssemblyItemProduct);
        }

    }

}
