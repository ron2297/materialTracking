using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MaterialTracking.Types;

namespace MaterialTracking.Web.Models
{
    public class ZoneViewModel
    {
        public int ZoneID { get; set; }
        public int SelectedZoneTypeID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ZoneTypeName { get; set; }
    }
}