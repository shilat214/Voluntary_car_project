using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceDAL
    {
        Voluntary_car_DBEntities1 DB= new Voluntary_car_DBEntities1 ();
        //החזרת כל השירותיפ
        public List<Services> GetServices() { 
            return DB.Services.ToList();
        }
    }
}
