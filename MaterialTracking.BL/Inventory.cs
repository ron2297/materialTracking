using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{

    public class InventoryClass : BaseClass
    {
        public List<Inventory> SelectAll()
        {
            return repository.SelectWithAssociations<Inventory>(new List<string> { "Product", "Zone" });
        }
        public Inventory SelectByID(int inventoryID)
        {
            return repository.Select<Inventory>(c => c.InventoryID == inventoryID).FirstOrDefault();
        }

        public Inventory Update(Inventory inventory)
        {
            return repository.Update<Inventory>(inventory);
        }

        public Inventory Insert(Inventory inventory)
        {
            return repository.Insert<Inventory>(inventory);
        }

        public Inventory SoftDelete(Inventory inventory)
        {

            return repository.Update<Inventory>(inventory);
        }

        public Inventory SoftDeleteByID(int inventoryID)
        {
            Inventory inventory = SelectByID(inventoryID);
            return SoftDelete(inventory);
        }

    }  
}
