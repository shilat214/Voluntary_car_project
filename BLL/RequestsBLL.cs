using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RequestsBLL
    {
        RequestsDAL requestsDAL = new RequestsDAL();
        VolunteerServicesBLL volunteerServicesBLL = new VolunteerServicesBLL();
        CarHelpRequestersBLL carHelpRequestersBLL = new CarHelpRequestersBLL();
        AssignmentsBLL AssignmentsBLL = new AssignmentsBLL();
        //פונקציה שמחזירה את כל הבקשות
        public List<RequestsDTO> Get_All_Requests()
        {
            return Converter.RequestsConverter.ToRequestsDTO(requestsDAL.Get_All_Requests());
        }
        //הוספת בקשה חדש לDB
        public bool Add_request(RequestsDTO RequestsDTO)
        {
            return requestsDAL.Add_request(Converter.RequestsConverter.ToRequests(RequestsDTO));

        }
        public List<Requests> Get_All_RequestsE()
        {
            return (requestsDAL.Get_All_Requests());
        }
        //צרי פונקצייה שתחזיר עבור כול מבקש עזרה את רשימת הבקשות הלא מאושרות שלו

        public IDictionary<CarHelpRequestersDTO, List<RequestsDTO>> Get_Unapproved_Requests_By_Requester()
        {
            List<CarHelpRequestersDTO> allCarHelpRequesters = carHelpRequestersBLL.Get_All_CarHelpRequesters(); // מחזיר את כל מבקשי העזרה
            IDictionary<CarHelpRequestersDTO, List<RequestsDTO>> result = new Dictionary<CarHelpRequestersDTO, List<RequestsDTO>>();
            List<RequestsDTO> requests = new List<RequestsDTO>();

            foreach (CarHelpRequestersDTO carHelpRequesters in allCarHelpRequesters)
            {

                requests = Get_All_Requests().FindAll(x => x.IdRequester == carHelpRequesters.IdRequester && x.RequestStatus.Trim()== "Pending");
                if(requests.Count>0)
                result.Add(carHelpRequesters, requests);
            }
            return result;
        }
        //  צרי פונקצייה שתחזיר את מבקש העזרה שיש לו הכי הרבה בקשות לא מאושרות
        public CarHelpRequestersDTO Get_CarHelpRequesters_Max_Unapproved_Requests()
        {
            Dictionary<CarHelpRequestersDTO, List<RequestsDTO>> result = Get_Unapproved_Requests_By_Requester().ToDictionary(x => x.Key, y => y.Value);

            return result.OrderByDescending(kvp => kvp.Value.Count).FirstOrDefault().Key;

        }

       // צרי פונקצייה שתקבל קוד מתנדב ותחזיר את הבקשות שביצע למבקש
        //העזרה שנעזר בו הכי הרבה פעמים- בחלוקה על פי תאריכים.מייני לפי
        //תאריכים
        public List<RequestsDTO> Get__Requests_Max_carHelpRequesters(string idv)
        {
            List<CarHelpRequestersDTO> carHelpRequestersDTOs = carHelpRequestersBLL.Get_All_CarHelpRequesters();
            List<Requests> requests = AssignmentsBLL.Get_All_Assignment().FindAll(x => x.IdVolunteer == idv).Select(x => x.Requests).ToList();
            List<RequestsDTO> result = new List<RequestsDTO>();
            int max = 0;
            string idc = "";
            foreach (CarHelpRequestersDTO carHelpRequestersDTO in carHelpRequestersDTOs)
            {
                int countC = requests.FindAll(X => X.CarHelpRequesters.IdRequester == carHelpRequestersDTO.IdRequester).Count();
                if (countC > max)
                {
                    max = countC;
                    idc = carHelpRequestersDTO.IdRequester;

                }

            }
            result = Converter.RequestsConverter.ToRequestsDTO(requestsDAL.Get_All_Requests().FindAll(x => x.CarHelpRequesters.IdRequester == idc));
            return result.OrderBy(x => x.RequestDate).ToList();
        }
        
    }
}