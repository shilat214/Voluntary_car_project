using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RequestsDAL
    {
        Voluntary_car_DBEntities1 DB = new Voluntary_car_DBEntities1();
        public List<Requests> Get_All_Requests()
        {
            return DB.Requests.ToList();
        }

        //הוספת בקשה חדשה ל DB
        public bool Add_request(Requests request)
        {
            bool f = true;
            try
            {
                DB.Requests.Add(request);
                DB.SaveChanges();

            }
            catch
            {
                f = false;
            }
            return f;
        }
    }
}
