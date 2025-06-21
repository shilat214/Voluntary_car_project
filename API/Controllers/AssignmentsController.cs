using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class AssignmentsController : ApiController
    {

        AssignmentsBLL AssignmentsBLL = new AssignmentsBLL();

        //  צרי פונקצייה שתקבל קוד מתנדב ותחזיר את רשימת הבקשות המשובצות
        //לו.
        [Route("api/AssignmentsBLL/Get_Assignments_By_Id_Volunteer/{idV}"), HttpGet]
        public IHttpActionResult Get_Assignments_By_Id_Volunteer( string idV)
        {

            if (idV == null)
            {
                return BadRequest("Id Volunteer  is required.");
            }
            if (AssignmentsBLL.Get_All_AssignmentDTO().Find(a => a.IdVolunteer == idV) == null)
            {
                return BadRequest("no exist Assignments for this id volunteer");
                //return NotFound();
            }

            return Ok(AssignmentsBLL.Get_Assignments_By_Id_Volunteer(idV));

        }
      
       
    }
}
