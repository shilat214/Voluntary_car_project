using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Converter
{
    public class AssignmentsConverter
    {
        public static AssignmentsDTO ToAssignmentsDTO(Assignments Assignment)
        {
            return new AssignmentsDTO()
            {
               IdAssignment = Assignment.IdAssignment,
               IdRequest = Assignment.IdRequest,
               IdVolunteer= Assignment.IdVolunteer,
               
            };
        }
        public static List<AssignmentsDTO> ToAssignmentsDTO(List<Assignments> Assignments)
        {
            return Assignments.Select(x => ToAssignmentsDTO(x)).ToList();
        }
    }
}
