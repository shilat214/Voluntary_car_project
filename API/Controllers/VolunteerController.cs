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
    public class VolunteerController : ApiController
    {
        VolunteerBLL VolunteerBLL = new VolunteerBLL();

        //הוספת מתנדב חדש לDB
        [Route("api/VolunteerBLL/Add_volunteer"), HttpPost]
        public IHttpActionResult Add_volunteer([FromBody] VolunteerDTO volunteerDTO)
        {

            if (volunteerDTO == null)
            {
                return BadRequest("Volunteer data is required.");
            }

            return Ok(VolunteerBLL.Add_volunteer(volunteerDTO));

        }
        //בדיקה האם מתנדב קיים
        [Route("api/VolunteerBLL/GetVolunteerById/{id}"), HttpGet]
        public IHttpActionResult GetVolunteerById(string id)
        {
            if (id == null)
            {
                return BadRequest("id volunteer  is required.");
            }
            if (VolunteerBLL.GetVolunteerById(id)== null)
            {
                return BadRequest("no exist volunteer with this id");
                //return NotFound();
            }

            return Ok(VolunteerBLL.GetVolunteerById(id));

        }
        // שליפת כל המתנדבים הקיימים לרשימה
        [Route("api/VolunteerBLL/GetVolunteers"), HttpGet]
        public IHttpActionResult GetVolunteers()
        {

            return Ok(VolunteerBLL.GetVolunteers());

        }
        //        צרי פונקצייה שתחזיר: שם מתנדב, שם מבקש עזרה, תאריך בקשה, תוכן
        //בקשה עבור כול הבקשות המאושרות-. צרי מחלקת עזר

        [Route("api/VolunteerBLL/Get_All_Details_for_approved_requests"), HttpGet]
        public IHttpActionResult Get_All_Details_for_approved_requests()
        {

            return Ok(VolunteerBLL.Get_All_Details_for_approved_requests());

        }
        // צרי פונקצייה שתחזיר לכול מתנדב את רשימת הבקשות הקרובות שלו מייני לפי שמות המתנדבים.  

        [Route("api/VolunteerBLL/Get__soon_Requests_volunteers"), HttpGet]
        public IHttpActionResult Get__soon_Requests_volunteers()
        {
            return Ok(VolunteerBLL.Get__soon_Requests_volunteers());

        }
        //        צרי פונקצייה שתחזיר עבור כול כתובת את רשימת המתנדבים שהולכים
        //להתנדב בה בחודש הקרוב.
        [Route("api/VolunteerBLL/GetListVolunteerOrderByAdress"), HttpGet]
        public IHttpActionResult GetListVolunteerOrderByAdress()
        {

            return Ok(VolunteerBLL.GetListVolunteerOrderByAdress());

        }

    }
}
