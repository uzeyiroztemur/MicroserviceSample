using Grpc.Net.Client;
using ManagementService.gRPCClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementService.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {

        }

        [Route("list")]
        [HttpGet]
        public ActionResult List()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7150");
            var client = new UserGRPC.UserGRPCClient(channel);


            var lst = client.UserList(new UserRequestModel { });

            //var list = UserGRPC.
            return Ok(lst.Users);
        }
    }
}
