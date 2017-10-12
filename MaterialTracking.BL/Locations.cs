using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class Locations : BaseClass
    {
        public List<Location> SelectAll()
        {
            return repository.Select<Location>(c => c.IsActive);
        }

        public Location SelectByID(int locationID)
        {
            return repository.Select<Location>(c => c.IsActive && c.LocationID == locationID).FirstOrDefault();
        }

        public Location Update(Location location)
        {
            return repository.Update<Location>(location);
        }

        public Location Insert(Location location)
        {
            return repository.Insert<Location>(location);
        }

        public Location SoftDelete(Location location)
        {
            location.IsActive = false;
            return repository.Update<Location>(location);
        }

        public Location SoftDeleteByID(int locationID)
        {
            Location location = SelectByID(locationID);
            return SoftDelete(location);
        }

    }
}
