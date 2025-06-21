using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BLL;

namespace API.Controllers
{
    public class ServiceController : ApiController
    {

        ServiceBLL ServiceBLL = new ServiceBLL();
        // שליפת כל השירותים הקיימים לרשימה
        [Route("api/ServiceBLL/GetServices"), HttpGet]
        public IHttpActionResult GetServices()
        {

            return Ok(ServiceBLL.GetServices());

        }

        //שליפת שירות שירות לפי שם השירות
        [Route("api/ServiceBLL/GetServicesByName/{name}"), HttpGet]
        public IHttpActionResult GetServicesByName(string name)
        {

            return Ok(ServiceBLL.GetServicesByName(name));

        }

       
    }
}
