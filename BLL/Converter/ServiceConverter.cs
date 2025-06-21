using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Converter
{
    public class ServiceConverter
    {
        public static ServiceDTO ToServiceDTO(Services services)
        {
            return new ServiceDTO()
            {IdService = services.IdService,
            ServiceName=services.ServiceName
            };
        }
        public static List<ServiceDTO> ToServiceDTO(List<Services> services)
        {
            return services.Select(x => ToServiceDTO(x)).ToList();
        }
    }
}
