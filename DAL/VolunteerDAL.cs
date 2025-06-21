using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VolunteerDAL
    {
        Voluntary_car_DBEntities1 DB = new Voluntary_car_DBEntities1();

        //החזרת כל המתנדבים שקיים לרשימה
        public List<Volunteers> GetVolunteers()
        {
            return DB.Volunteers.ToList();

        }
 

        //הוספת מתנדב חדש ל DB
        public bool Add_volunteer(Volunteers volunteer)
        {
            bool f = true;
            try
            {
                DB.Volunteers.Add(volunteer);
                DB.SaveChanges();

            }
            catch
            {
                f = false;
            }
            return f;
        }
        //קריאה לפונקציה 
        //צרי פונקציה שתקבל קוד מתנדב ותחזיר כמה שעות חודשיות נותרו לו החודש
        public int GetCountHourMonth(string id)
        {
            var idV = new SqlParameter
            {
                ParameterName = "@idVolunteer",
                SqlDbType = System.Data.SqlDbType.NChar,
                Size = 9,
                Value = id,
            };
            return
                DB.Database.SqlQuery<int>("SELECT dbo.CountHourMonth(@idVolunteer)", idV).FirstOrDefault();

        }
        //        --3 צרי פרוצדורה שתקבל קוד שירות ותחזיר כמה מתנדבים יש בשירת זה וכמה
        //--בקשות אושרו בשירות זה השנה.
        public void CountVolunteerAndRequestsYearInService(int serviceId, out int countVolunteers, out int countRequests)
        {

            var countV = new SqlParameter
            {
                ParameterName = "@countV",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            var countR = new SqlParameter
            {
                ParameterName = "@countR",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            var paramServiceId = new SqlParameter
            {
                ParameterName = "@serviceId",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = serviceId
            };

            DB.Database.ExecuteSqlCommand("exec CountVolunteerAndRequestsYearInService @serviceId, @countV output, @countR output", paramServiceId, countV, countR);
            countVolunteers = (int)(countV.Value != null ? countV.Value : 0);
            countRequests = (int)(countR.Value != null ? countR.Value : 0);
        }
        //--מקבלת קוד מתנדב ומחזירה כמה שעות תרם החודש וממוצע השעות שתרם חודש שעבר
        public void CountHoursAndAvgHourLastMonth(string VolunteerId, out int HoursThisMonth, out float AverageHoursPerMonth)
        {

            var hoursThisMonth = new SqlParameter
            {
                ParameterName = "@HoursThisMonth",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };
            var averageHoursPerMonth = new SqlParameter
            {
                ParameterName = "@AverageHoursPerMonth",
                SqlDbType = System.Data.SqlDbType.Float,
                Direction = System.Data.ParameterDirection.Output,
            };
            var paramVolunteerId = new SqlParameter
            {
                ParameterName = "@VolunteerId",
                SqlDbType = System.Data.SqlDbType.NChar,
                Value = VolunteerId
            };

            DB.Database.ExecuteSqlCommand("exec CountHoursAndAvgHourLastYear @VolunteerId, @HoursThisMonth output, @AverageHoursPerMonth output", paramVolunteerId, hoursThisMonth, averageHoursPerMonth);
            HoursThisMonth = hoursThisMonth.Value != null ? Convert.ToInt32(hoursThisMonth.Value) : 0;
            AverageHoursPerMonth = averageHoursPerMonth.Value != null ? Convert.ToSingle(averageHoursPerMonth.Value) : 0;

        }
        //-- פרוזדורה המקבלת קוד מתנדב ושולפת שם נכה, פלאפון , כתובות, שם שירות, תוכן הבקשה, תאריך עבור כל הבקשות הקרובות שלו ממויין לפי תאריך
        public List<GetUpcomingRequestsForVolunteer_Result> GetUpcomingRequestsForVolunteer(string VolunteerId)
        {
            return DB.GetUpcomingRequestsForVolunteer(VolunteerId).ToList();
        }
        //         --2 צרי פרוצדורה שתקבל קוד שירות ותשלוף את המתנדבים שנותרו לו הכי 
        //--הרבה שעות לתרום החודש בשירות זה.
        public List<GetVolunteerMaxCountHourMonth_Result> GetVolunteerMaxCountHourMonth(int idS)
        {
            return DB.GetVolunteerMaxCountHourMonth(idS).ToList();
        }
        //        -- 5 צרי פונקצייה שתקבל קוד מתנדב ותחזיר כמה שירותים הוא נותן- ואין עוד 
        //--שנותנים כזה שירות
        public int GetCount_Unique_Services_By_Volunteer(string id)
        {
            var idV = new SqlParameter
            {
                ParameterName = "@VolunteerId",
                SqlDbType = System.Data.SqlDbType.NChar,
                Size = 9,
                Value = id,
            };
            return
                DB.Database.SqlQuery<int>("SELECT dbo.Count_Unique_Services_By_Volunteer(@VolunteerId)", idV).FirstOrDefault();

        }
    }
}
