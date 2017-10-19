using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    class InventoryClass:BaseClass
    {
  
        public Inventory SelectByID(int InventoryID)
        {
            return repository.Select<Inventory>(c=>c.InventoryID == InventoryID).FirstOrDefault();
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

        public Inventory SoftDeleteByID(int InventoryID)
        {
            Inventory inventory = SelectByID(InventoryID);
            return SoftDelete(inventory);
        }

    }
}
