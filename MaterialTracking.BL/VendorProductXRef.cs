using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;



namespace MaterialTracking.BL
{

    public class VendorProductXRefs : BaseClass
    {
        public List<VendorProductXRef> SelectAll()
        {
            return repository.SelectWithAssociations<VendorProductXRef>(new List<string> { "Product", "Vendor" });
        }
        public VendorProductXRef SelectByID(int vendorID)
        {
            return repository.Select<VendorProductXRef>(c => c.VendorID == vendorID).FirstOrDefault();
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

            return repository.Update<VendorProductXRef>(vendorproduct);
        }

        public VendorProductXRef SoftDeleteByID(int vendorproductID)
        {
            VendorProductXRef vendorproduct = SelectByID(vendorproductID);
            return SoftDelete(vendorproduct);
        }

    }

}
