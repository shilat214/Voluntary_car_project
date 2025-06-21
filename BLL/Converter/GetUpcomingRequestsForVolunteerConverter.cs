using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converter
{
    public class GetUpcomingRequestsForVolunteerConverter
    {
        public static GetUpcomingRequestsForVolunteerDTO ToGetUpcomingRequestsForVolunteerDTO(GetUpcomingRequestsForVolunteer_Result getUpcomingRequestsForVolunteer_Result)
        {
            return new GetUpcomingRequestsForVolunteerDTO()
            {
               Address=getUpcomingRequestsForVolunteer_Result.Address,
               Name=getUpcomingRequestsForVolunteer_Result.Name,
                Phone = getUpcomingRequestsForVolunteer_Result.Phone,
                ServiceName = getUpcomingRequestsForVolunteer_Result.ServiceName,
                RequestDate= getUpcomingRequestsForVolunteer_Result.RequestDate,
                RequestText= getUpcomingRequestsForVolunteer_Result.RequestText,
            };
        }
        public static List<GetUpcomingRequestsForVolunteerDTO> ToGetUpcomingRequestsForVolunteerDTO(List<GetUpcomingRequestsForVolunteer_Result> getUpcomingRequestsForVolunteer_Results)
        {
            return getUpcomingRequestsForVolunteer_Results.Select(x => ToGetUpcomingRequestsForVolunteerDTO(x)).ToList();
        }
    }
}
