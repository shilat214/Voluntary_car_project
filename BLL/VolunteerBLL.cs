using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VolunteerBLL
    {
        VolunteerDAL VolunteerDAL = new VolunteerDAL();
        RequestsBLL RequestsBLL = new RequestsBLL();
        AssignmentsBLL assignmentsBLL = new AssignmentsBLL();
        CarHelpRequestersBLL carHelpRequestersBLL = new CarHelpRequestersBLL();
        VolunteerServicesBLL VolunteerServicesBLL = new VolunteerServicesBLL();
        //בדיקה האם מתנדב קיים
        public VolunteerDTO GetVolunteerById( string id)
        {
           Volunteers v=VolunteerDAL.GetVolunteers().Find(x => x.IdVolunteer.Equals( id));
            if (v != null)
                return Converter.VolunteerConverter.ToVolunteerDTO(v);
            return null;
        }

        //        צרי פונקצייה שתחזיר: שם מתנדב, שם מבקש עזרה, תאריך בקשה, תוכן
        //בקשה עבור כול הבקשות המאושרות-. צרי מחלקת עזר
        public List<Details_for_approved_requestsDTO> Get_All_Details_for_approved_requests()
        {
            List<Details_for_approved_requestsDTO> details_for_approved_requestsDTO = new List<Details_for_approved_requestsDTO>();

            foreach (Requests request in RequestsBLL.Get_All_RequestsE().FindAll(x => x.RequestStatus.Trim().Equals("Approved")))
            {
                details_for_approved_requestsDTO.Add(new Details_for_approved_requestsDTO
                {
                    NameCarHelpRequester = request.CarHelpRequesters.Name,
                    NameVolunteer = GetVolunteers().Find(x => x.IdVolunteer == (VolunteerServicesBLL.GetVolunteerServices().Find(X => X.IdService == request.IdService).IdVolunteer)).Name,
                    RequestContent = request.RequestText,
                    Date = (DateTime)request.RequestDate
                }

                    ); ;

            }
            return details_for_approved_requestsDTO;
        }
        //החזרת כל המתנדבים שקיים לרשימה
        public List<VolunteerDTO> GetVolunteers()
        {
            return Converter.VolunteerConverter.ToVolunteerDTO(VolunteerDAL.GetVolunteers());

        }
        //הוספת מתנב חדש לDB
        public bool Add_volunteer(VolunteerDTO volunteerDTO)
        {
            return VolunteerDAL.Add_volunteer(Converter.VolunteerConverter.ToVolunteer(volunteerDTO));

        }
        //קריאה לפונקציה 
        //צרי פונקציה שתקבל קוד מתנדב ותחזיר כמה שעות חודשיות נותרו לו החודש
        public int GetCountHourMonth(string id)
        {
            return VolunteerDAL.GetCountHourMonth(id);
        }



        // צרי פונקצייה שתחזיר לכול מתנדב את רשימת הבקשות הקרובות שלו מייני לפי שמות המתנדבים.  
        //VolunteerDTOלשאול אם לשים שמות או את כל ה
        public IDictionary<VolunteerDTO, List<RequestsDTO>> Get__soon_Requests_volunteers()
        {
            IDictionary<VolunteerDTO, List<RequestsDTO>> result = new Dictionary<VolunteerDTO, List<RequestsDTO>>();
            List<Requests> allRequests = RequestsBLL.Get_All_RequestsE();
            List<Volunteers> volunteers = VolunteerDAL.GetVolunteers().OrderBy(x => x.Name).ToList();
            foreach (Volunteers v in volunteers)
            {
                List<RequestsDTO> futureRequests = Converter.RequestsConverter.ToRequestsDTO(allRequests.FindAll(x => x.Assignments.FirstOrDefault() != null && x.Assignments.FirstOrDefault().IdVolunteer == v.IdVolunteer && x.RequestDate > DateTime.Now).ToList());
                if (futureRequests.Count > 0)
                {
                    result.Add(Converter.VolunteerConverter.ToVolunteerDTO(v), futureRequests);
                }
            }

            return result;
        }

        //        צרי פונקצייה שתחזיר עבור כול כתובת את רשימת המתנדבים שהולכים
        //להתנדב בה בחודש הקרוב.
        public IDictionary<string, List<VolunteerDTO>> GetListVolunteerOrderByAdress()
        {
            List<string> adress = assignmentsBLL.Get_All_Assignment().Select(x => x.Requests.CarHelpRequesters.Address).Distinct().ToList();
            List<VolunteerDTO> resultVolunteer = new List<VolunteerDTO>();
            IDictionary<string, List<VolunteerDTO>> result = new Dictionary<string, List<VolunteerDTO>>();
            foreach (string item in adress)
            {
                resultVolunteer = Converter.VolunteerConverter.ToVolunteerDTO(RequestsBLL.Get_All_RequestsE().FindAll(x => x.RequestDate.Value.Month == DateTime.Now.Month && x.CarHelpRequesters.Address.Trim() == item && x.RequestStatus.Trim() == "Approved").Select(x => x.Assignments.FirstOrDefault().Volunteers).ToList());
                result.Add(item, resultVolunteer);
            }
            return result;
        }
        //        --3 צרי פרוצדורה שתקבל קוד שירות ותחזיר כמה מתנדבים יש בשירת זה וכמה
        //--בקשות אושרו בשירות זה השנה.
        public void CountVolunteerAndRequestsYearInService(int idS, out int countV, out int countR)
        {
            VolunteerDAL.CountVolunteerAndRequestsYearInService(idS, out countV, out countR);
        }
        //--מקבלת קוד מתנדב ומחזירה כמה שעות תרם החודש וממוצע השעות שתרם חודש שעבר
        public void CountHoursAndAvgHourLastMonth(string VolunteerId, out int HoursThisMonth, out float AverageHoursPerMonth)
        {
            VolunteerDAL.CountHoursAndAvgHourLastMonth(VolunteerId, out HoursThisMonth, out AverageHoursPerMonth);
        }
        //-- פרוזדורה המקבלת קוד מתנדב ושולפת שם נכה, פלאפון , כתובות, שם שירות, תוכן הבקשה, תאריך עבור כל הבקשות הקרובות שלו ממויין לפי תאריך
        public List<GetUpcomingRequestsForVolunteerDTO> GetUpcomingRequestsForVolunteer(string VolunteerId)
        {
            return Converter.GetUpcomingRequestsForVolunteerConverter.ToGetUpcomingRequestsForVolunteerDTO(VolunteerDAL.GetUpcomingRequestsForVolunteer(VolunteerId)).ToList();
        }
        //         --2 צרי פרוצדורה שתקבל קוד שירות ותשלוף את המתנדבים שנותרו לו הכי 
        //--הרבה שעות לתרום החודש בשירות זה.
        public List<GetVolunteerMaxCountHourMonthDTO> GetVolunteerMaxCountHourMonth(int idS)
        {
            return Converter.GetVolunteerMaxCountHourMonthConverter.ToGetVolunteerMaxCountHourMonthDTO(VolunteerDAL.GetVolunteerMaxCountHourMonth(idS)).ToList();
        }
        //        -- 5 צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שירותים הוא נותן- ואין עוד 
        //--שנותנים כזה שירות
        public int GetCount_Unique_Services_By_Volunteer(string id)
        {
           return VolunteerDAL.GetCount_Unique_Services_By_Volunteer(id);
        }
    }
}
