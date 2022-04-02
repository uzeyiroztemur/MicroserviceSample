using Microservice.Core.Utilities.ReturnData;
using Microsoft.AspNetCore.Mvc;

namespace UserPortalService.RestApi.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        [Route("healt-check")]
        public ActionResult Get()
        {
            return Ok(new ReturnData<bool> { Data = true, Message = "Ok" });
        }
    }
}