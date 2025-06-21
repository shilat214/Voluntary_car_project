using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarHelpRequestersControler : ControllerBase
    {

        CarHelpRequestersBLL carHelpRequestersBLL = new CarHelpRequestersBLL();
        [Route("Get_All_CarHelpRequesters"), HttpGet]
        public ActionResult Get_All_CarHelpRequesters()
        {
            return Ok(carHelpRequestersBLL.Get_All_CarHelpRequesters());
        }
    }
}
