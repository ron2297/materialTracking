using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaterialTracking.Types;

namespace MaterialTracking.Web.Models
{
    public class AssemblyViewModel
    {
        public int AssemblyItemID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }
        public List<Product> Products { get; set; }
       
    }
}