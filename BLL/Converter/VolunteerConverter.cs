using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL.Converter
{
    public class VolunteerConverter
    {
        public static VolunteerDTO ToVolunteerDTO(Volunteers volunteer)
        {
            return new VolunteerDTO()
            {
                IdVolunteer = volunteer.IdVolunteer,
                Name = volunteer.Name,
                Phone = volunteer.Phone
            };
        }
        public static List<VolunteerDTO> ToVolunteerDTO(List<Volunteers> volunteers)
        {
            return volunteers.Select(x => ToVolunteerDTO(x)).ToList();
        }

        public static Volunteers ToVolunteer(VolunteerDTO volunteerDTO)
        {
            return new Volunteers()
            {
                IdVolunteer = volunteerDTO.IdVolunteer,
                Name = volunteerDTO.Name,
                Phone = volunteerDTO.Phone
            };
        }
        public static List<Volunteers> ToVolunteer(List<VolunteerDTO> volunteerDTO)
        {
            return volunteerDTO.Select(x => ToVolunteer(x)).ToList();
        }
    }
}
