using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaterialTracking.Types;

namespace MaterialTracking.Web.Models
{
    public class AssemblyProductViewModel
    {
        public int AssemblyItemID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }

    }
}