using MediatR;
using Microservice.Core.Utilities.ReturnData.Enum;
using Microsoft.AspNetCore.Mvc;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.AuthFeature.Queries;
using UserPortalService.Entities.AuthFeature.Commands;

namespace UserPortalService.RestApi.Controllers
{
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        private readonly IMediator _mediator;

        public AuthController(IAuthService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }

        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterCommand userRegisterCommand)
        {
            var res = await _mediator.Send(userRegisterCommand);
            return res.Status == ReturnDataStatusEnum.Success ? Created(string.Empty, res) : BadRequest(res);
        }

        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login(UserLogingCommandQuery userLogingCommandQuery)
        {
            var res = await _mediator.Send(userLogingCommandQuery);
            return res.Status == ReturnDataStatusEnum.Success ? Created(string.Empty, res) : BadRequest(res);
        }
    }
}
