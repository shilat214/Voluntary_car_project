using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VolunteerServicesBLL
    {
        VolunteerServicesDAL  VolunteerServicesDAL= new VolunteerServicesDAL();
        //מחזירה את כל שירות מתנדב
        public List<VolunteerServices> GetVolunteerServices()
        {
            return VolunteerServicesDAL.GetVolunteerServices();
        }
    }
}
