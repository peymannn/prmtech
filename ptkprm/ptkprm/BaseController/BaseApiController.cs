using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ptkprm.BaseController
{
   
    public class BaseApiController : ControllerBase
    {
        [NonAction]
        public string HeartBeat()
        {
            return DateTime.UtcNow.ToLongDateString();
        }
    }
}
