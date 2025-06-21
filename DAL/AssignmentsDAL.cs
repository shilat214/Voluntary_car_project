using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AssignmentsDAL
    {
        Voluntary_car_DBEntities1 DB = new Voluntary_car_DBEntities1();

        //החזרת כל הבקשות המשובצות  לרשימה
     
        public List<Assignments> Get_All_Assignment()
        {
            return DB.Assignments.ToList();
        }
    }
}
