using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaterialTracking.Web.Models
{
    public class OrderDetailsViewModel
    {
        public int OrderRequestID { get; set; }
        public int OrderDetailsID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public int Quantity { get; set; }

    }
}