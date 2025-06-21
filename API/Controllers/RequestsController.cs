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
    public class RequestsController : ApiController
    {
        //צרי פונקצייה שתחזיר עבור כול מבקש עזרה את רשימת הבקשות הלא מאושרות שלו
        RequestsBLL RequestsBLL = new RequestsBLL();
        VolunteerBLL volunteerBLL = new VolunteerBLL();

        [Route("api/RequestsBLL/Get_Unapproved_Requests_By_Requester"), HttpGet]
        public IHttpActionResult Get_Unapproved_Requests_By_Requester()
        {

            return Ok(RequestsBLL.Get_Unapproved_Requests_By_Requester());

        }
       
        // הוספת בקשה חדשה
        [Route("api/RequestsBLL/Add_request"), HttpPost]
        public IHttpActionResult Add_request([FromBody] RequestsDTO requestsDTO)
        {
            if (requestsDTO == null)
            {
                return BadRequest("requests data is required.");
            }

            return Ok(RequestsBLL.Add_request(requestsDTO));

        }
        // שליפת כל הבקשות לרשימה
        [Route("api/RequestsBLL/Get_All_Requests"), HttpGet]
        public IHttpActionResult Get_All_Requests()
        {

            return Ok(RequestsBLL.Get_All_Requests());

        }
            // צרי פונקצייה שתקבל קוד מתנדב ותחזיר את הבקשות שביצע למבקש
            //העזרה שנעזר בו הכי הרבה פעמים- בחלוקה על פי תאריכים.מייני לפי
            //תאריכים

            [Route("api/RequestsBLL/Get__Requests_Max_carHelpRequesters/{idv}"), HttpGet]
        public IHttpActionResult Get__Requests_Max_carHelpRequesters(string idv)
        {

            if (idv == null)
            {
                return BadRequest("id volunteer  is required.");
            }
            if (volunteerBLL.GetVolunteers().Find(a => a.IdVolunteer == idv) == null)
            {
                return BadRequest("no exist volunteer with this id");
                //return NotFound();
            }

            return Ok(RequestsBLL.Get__Requests_Max_carHelpRequesters(idv));

        }
    }
}
