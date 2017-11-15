using System;
using System.Collections.Generic;
using System.Linq;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class AssemblyItemProducts : BaseClass
    {

        public List<AssemblyItemProduct> SelectByAssemblyID(int assemblyID)
        {
            return repository.SelectWithAssociations<AssemblyItemProduct>(new List<string> { "Product" }, c => c.IsActive && c.AssemblyItemID == assemblyID);
        }


        public AssemblyItemProduct Insert(AssemblyItemProduct assemblyItemProduct)
        {
            return repository.Insert<AssemblyItemProduct>(assemblyItemProduct);
        }


        public void DeleteByAssemblyID(int assemblyID)
        {
            List<AssemblyItemProduct> aip = SelectByAssemblyID(assemblyID);
            foreach (AssemblyItemProduct item in aip)
            {
                repository.Delete(item);
            }
        }

        public AssemblyItemProduct Update(AssemblyItemProduct assemblyItemProduct)
        {
            if (repository.DoesExist<AssemblyItemProduct>(assemblyItemProduct))
            {
                return repository.Update<AssemblyItemProduct>(assemblyItemProduct);
            }
            else
            {
                return repository.Insert<AssemblyItemProduct>(assemblyItemProduct);
            }

        }

        public void Delete(AssemblyItemProduct assemblyItemProduct)
        {
            repository.Delete(assemblyItemProduct);
        }

    }
}
