using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ServiceBLL
    {
        ServiceDAL ServiceDAL = new ServiceDAL();

        //החזרת כל השירותיפ
        public List<ServiceDTO> GetServices()
        {
            return Converter.ServiceConverter.ToServiceDTO(ServiceDAL.GetServices());
        }

        //שליפת שירות שירות לפי שם השירות
        public string GetServicesByName(string name)
        {


            if( (ServiceDAL.GetServices().Find(x => x.ServiceName.Trim().Equals(name.Trim()))) != null)
            {
                return ServiceDAL.GetServices().Find(x => x.ServiceName.Trim().Equals(name)).IdService;
            }
            return "no exist";
        }
    }
}
