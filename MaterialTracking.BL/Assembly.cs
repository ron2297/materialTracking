using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class Assembly : BaseClass
    {
        public List<AssemblyItem> SelectAll()
        {
            return repository.Select<AssemblyItem>(c => c.IsActive);
        }

        public AssemblyItem SelectByID(int assemblyItemID)
        {
            return repository.Select<AssemblyItem>(c => c.IsActive && c.AssemblyItemID == assemblyItemID).FirstOrDefault();
        }

        public AssemblyItem Update(AssemblyItem assemblyItem)
        {
            return repository.Update<AssemblyItem>(assemblyItem);
        }

        public AssemblyItem Insert(AssemblyItem assemblyItem)
        {
            return repository.Insert<AssemblyItem>(assemblyItem);
        }

        public AssemblyItem SoftDelete(AssemblyItem assemblyItem)
        {
            assemblyItem.IsActive = false;
            return repository.Update<AssemblyItem>(assemblyItem);
        }

        public AssemblyItem SoftDeleteByID(int assemblyItemID)
        {
            AssemblyItem assemblyItem = SelectByID(assemblyItemID);
            return SoftDelete(assemblyItem);
        }
    }
}
