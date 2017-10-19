using BBS.Repository;
using MaterialTracking.Types;

namespace MaterialTracking.BL
{
    public class BaseClass
    {
        public GenericRepository<MaterialTrackingDBEntities> repository = new GenericRepository<MaterialTrackingDBEntities>();
    }
}
