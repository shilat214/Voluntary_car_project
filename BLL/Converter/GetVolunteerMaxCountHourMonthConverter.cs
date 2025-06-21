using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converter
{
    public class GetVolunteerMaxCountHourMonthConverter
    {
        public static GetVolunteerMaxCountHourMonthDTO ToGetVolunteerMaxCountHourMonthDTO(GetVolunteerMaxCountHourMonth_Result getUpcomingRequestsForVolunteer_Result)
        {
            return new GetVolunteerMaxCountHourMonthDTO()
            {
               IdVolunteer=getUpcomingRequestsForVolunteer_Result.IdVolunteer,
               Name=getUpcomingRequestsForVolunteer_Result.Name,
               Phone=getUpcomingRequestsForVolunteer_Result.Phone
            };
        }
        public static List<GetVolunteerMaxCountHourMonthDTO> ToGetVolunteerMaxCountHourMonthDTO(List<GetVolunteerMaxCountHourMonth_Result> getVolunteerMaxCountHourMonth_Results)
        {
            return getVolunteerMaxCountHourMonth_Results.Select(x => ToGetVolunteerMaxCountHourMonthDTO(x)).ToList();
        }
    }
}
