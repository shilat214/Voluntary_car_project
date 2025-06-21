using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Details_for_approved_requestsDTO
    {
        //        צרי פונקצייה שתחזיר: שם מתנדב, שם מבקש עזרה, תאריך בקשה, תוכן
        //בקשה עבור כול הבקשות המאושרות-. צרי מחלקת עזר

        public string NameVolunteer { get; set; }
        public string NameCarHelpRequester { get; set; }
        public DateTime Date { get; set; }
        public string RequestContent { get; set; }



    }
}
