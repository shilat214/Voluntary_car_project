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
    public class CarHelpRequestersBLL
    {
        CarHelpRequestersDAL CarHelpRequestersDAL = new CarHelpRequestersDAL();
       
        //מחזיר את כל מבקשי העזרה
        public List<CarHelpRequestersDTO> Get_All_CarHelpRequesters()
        {
            return Converter.CarHelpRequestersConverter.ToCarHelpRequestersDTO(CarHelpRequestersDAL.Get_All_CarHelpRequesters());
        }
        //החזרת מבקש עזרה לפי id 

        public CarHelpRequestersDTO GetRequesterById(String id)
        {

            CarHelpRequesters c = CarHelpRequestersDAL.Get_All_CarHelpRequesters().Find(x => x.IdRequester.Equals(id));
            if (c != null)
                return Converter.CarHelpRequestersConverter.ToCarHelpRequestersDTO(c);
            return null;

        }
        //הוספת מבקש שירות חדש לDB
        public bool Add_CarHelpRequester(CarHelpRequestersDTO carHelpRequestersDTO)
        {
            return CarHelpRequestersDAL.Add_CarHelpRequester(Converter.CarHelpRequestersConverter.ToCarHelpRequesters(carHelpRequestersDTO));

        }
        //        --4 צרי פונקצייה שתקבל קוד שירות ותחזיר האם יש מספיק שעות שנתרמו-
        //--האם מספר השעות שנתרמו בחודש גדול מהממוצע שעות שמבקשים 
        //--בחודש.
        public bool IsServiceHoursSufficientThisMonth(int idS)
        {
           return CarHelpRequestersDAL.IsServiceHoursSufficientThisMonth(idS);
        }

    }
}
