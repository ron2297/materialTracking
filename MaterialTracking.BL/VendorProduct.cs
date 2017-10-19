using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    class VendorProductsClass:BaseClass
    {
        public List<VendorProductXRef> SelectAll()
        {
            return repository.Select<VendorProductXRef>(c => c.IsActive);
        }

        public VendorProductXRef SelectByID(int vendorproductID)
        {
            return repository.Select<VendorProductXRef>(c => c.IsActive && c.VendorID == vendorproductID).FirstOrDefault();
        }

        public VendorProductXRef Update(VendorProductXRef vendorproduct)
        {
            return repository.Update<VendorProductXRef>(vendorproduct);
        }

        public VendorProductXRef Insert(VendorProductXRef vendorproduct)
        {
            return repository.Insert<VendorProductXRef>(vendorproduct);
        }

        public VendorProductXRef SoftDelete(VendorProductXRef vendorproduct)
        {
            vendorproduct.IsActive = false;
            return repository.Update<VendorProductXRef>(vendorproduct);
        }

        public VendorProductXRef SoftDeleteByID(int vendorproductID)
        {
            VendorProductXRef vendorproduct = SelectByID(vendorproductID);
            return SoftDelete(vendorproduct);
        }
    }
}
