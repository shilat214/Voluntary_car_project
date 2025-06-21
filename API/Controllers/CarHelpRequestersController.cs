using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DTO;

namespace API.Controllers
{
    public class CarHelpRequestersController : ApiController
    {
        RequestsBLL RequestsBLL = new RequestsBLL();
        CarHelpRequestersBLL CarHelpRequestersBLL = new CarHelpRequestersBLL();

        //צרי פונקצייה שתחזיר את מבקש העזרה שיש לו הכי הרבה בקשות לא מאושרות. 
        
        [Route("api/CarHelpRequesters/Get_CarHelpRequesters_Max_Unapproved_Requests"), HttpGet]
        public IHttpActionResult Get_CarHelpRequesters_Max_Unapproved_Requests()
        {
            return Ok(RequestsBLL.Get_CarHelpRequesters_Max_Unapproved_Requests());
        }
        //הוספת מבקש חדש 
        [Route("api/CarHelpRequestersBLL/Add_CarHelpRequester"), HttpPost]
        public IHttpActionResult Add_Request([FromBody] CarHelpRequestersDTO c)
        {

            if (c == null)
            {
                return BadRequest("Car Help Requesters is required.");
            }

            return Ok(CarHelpRequestersBLL.Add_CarHelpRequester(c));

        }

        //בדיקה האם מבקש עזרה קיים
        [Route("api/CarHelpRequestersBLL/GetRequesterById/{id}"), HttpGet]
        public IHttpActionResult GetRequesterById(string id)
        {
            if (id == null)
            {
                return BadRequest("id requster  is required.");
            }
            if (CarHelpRequestersBLL.GetRequesterById(id) == null)
            {
                return BadRequest("no exist requester with this id");
                //return NotFound();
            }

            return Ok(CarHelpRequestersBLL.GetRequesterById(id));

        }
    }
}
