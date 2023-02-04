using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ptkprm.BaseController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiTestController : BaseApiController
    {

        [HttpGet]
        public string Get(string value)
        {
            return value;
        }



        [HttpPost]
        public string HeartBeat()
        {
            return base.HeartBeat();
        }

    }
}
