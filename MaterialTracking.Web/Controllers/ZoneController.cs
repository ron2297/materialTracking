using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MaterialTracking.Types;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MaterialTracking.Web.Models;

namespace MaterialTracking.Web.Controllers
{
    public class ZoneController : BaseController
    {
        public ActionResult Index()
        {
            BL.Zones blZone = new BL.Zones();
            BL.ZoneTypes blZoneTypes = new BL.ZoneTypes();
            //Get the ZoneTypes and Zones
            List<ZoneType> zoneTypes = blZoneTypes.SelectAll();
            List<Zone> zones = blZone.SelectAll();

            List<ZoneViewModel> model = new List<ZoneViewModel>();

            //Merge the two into a view model
            foreach (Zone zone in zones)
            {
                ZoneViewModel vm = new ZoneViewModel
                {
                    IsActive = zone.IsActive,
                    Name = zone.Name,
                    ZoneID = (int)zone.ZoneID,
                    SelectedZoneTypeID = zone.ZoneTypeID,
                    ZoneTypeName = zoneTypes.Where(c => c.ZoneTypeID == zone.ZoneTypeID).Select(c => c.Name).FirstOrDefault()
            };
                model.Add(vm);
            }

            //Place in Viewbag for use in template
            TempData["ZT"] = zoneTypes;
            ViewBag.vbZoneTypes = zoneTypes;
            return View(model);
        }

        #region AJAX Actions

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneUpdate([DataSourceRequest] DataSourceRequest request, ZoneViewModel zoneViewModel)
        {
            BL.Zones blZones = new BL.Zones();
            Zone zone = new Zone
            {
                IsActive = zoneViewModel.IsActive,
                Name = zoneViewModel.Name,
                ZoneID = zoneViewModel.ZoneID,
                ZoneTypeID = zoneViewModel.SelectedZoneTypeID
            };
            blZones.Update(zone);
            return Json(new[] { zoneViewModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneCreate([DataSourceRequest] DataSourceRequest request, ZoneViewModel zoneViewModel)
        {
            BL.Zones blZones = new BL.Zones();
            Zone zone = new Zone
            {
                IsActive = zoneViewModel.IsActive,
                Name = zoneViewModel.Name,
                ZoneTypeID = zoneViewModel.SelectedZoneTypeID
            };
            Zone model = blZones.Insert(zone);
            zoneViewModel.ZoneID = zone.ZoneID;
            return Json(new[] { zoneViewModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ZoneDestroy([DataSourceRequest] DataSourceRequest request, ZoneViewModel zoneViewModel)
        {
            BL.Zones blZones = new BL.Zones();
            Zone zone = new Zone
            {
                IsActive = zoneViewModel.IsActive,
                Name = zoneViewModel.Name,
                ZoneID = zoneViewModel.ZoneID,
                ZoneTypeID = zoneViewModel.SelectedZoneTypeID
            };
            blZones.SoftDelete(zone);
            zoneViewModel.IsActive = false;
            return Json(new[] { zoneViewModel }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        #endregion AJAX Actions
    }
}