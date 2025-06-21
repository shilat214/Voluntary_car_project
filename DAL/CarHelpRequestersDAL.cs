using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CarHelpRequestersDAL
    {
        Voluntary_car_DBEntities1 DB = new Voluntary_car_DBEntities1();
        public List<CarHelpRequesters> Get_All_CarHelpRequesters()
        {
            return DB.CarHelpRequesters.ToList();
        }
        //הוספת מבקש שירות חדש ל DB
        public bool Add_CarHelpRequester(CarHelpRequesters carHelpRequesters)
        {
            bool f = true;
            try
            {
                DB.CarHelpRequesters.Add(carHelpRequesters);
                DB.SaveChanges();

            }
            catch
            {
                f = false;
            }
            return f;
        }
        //        --4 צרי פונקצייה שתקבל קוד שירות ותחזיר האם יש מספיק שעות שנתרמו-
        //--האם מספר השעות שנתרמו בחודש גדול מהממוצע שעות שמבקשים 
        //--בחודש.
        public bool IsServiceHoursSufficientThisMonth(int idS)
        {
            var idSer = new SqlParameter
            {
                ParameterName = "@idService",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 9,
                Value = idS,
            };
            return DB.Database.SqlQuery<bool>("SELECT dbo.IsServiceHoursSufficientThisMonth(@idService)", idSer).FirstOrDefault();
        }
    }
}
