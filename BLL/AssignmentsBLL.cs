using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class AssignmentsBLL
    {
        AssignmentsDAL assignmentsDAL = new AssignmentsDAL();

        //החזרת כל הבקשות המשובצות  לרשימה
        public List<AssignmentsDTO> Get_All_AssignmentDTO()
        {
            return Converter.AssignmentsConverter.ToAssignmentsDTO( assignmentsDAL.Get_All_Assignment());

        }
        public List<Assignments> Get_All_Assignment()
        {
            return assignmentsDAL.Get_All_Assignment();

        }

        //  .צרי פונקצייה שתקבל קוד מתנדב ותחזיר את רשימת הבקשות המשובצות לו
        public List<AssignmentsDTO> Get_Assignments_By_Id_Volunteer(string idv)
        {
            return Converter.AssignmentsConverter.ToAssignmentsDTO( assignmentsDAL.Get_All_Assignment().FindAll(x => x.IdVolunteer == idv));

        }


    }
}
