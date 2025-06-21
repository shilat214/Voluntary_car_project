using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VolunteerServicesDAL
    {
        Voluntary_car_DBEntities1 DB = new Voluntary_car_DBEntities1();
        public List<VolunteerServices> GetVolunteerServices()
        {
            return DB.VolunteerServices.ToList();
        }
    }
}
