using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.AuthFeature.Commands;

namespace UserPortalService.RestApi.Controllers
{
    public class UserController : BaseController
    {
        private IAuthService _authService;
        private readonly IMediator _mediator;

        public UserController(IAuthService authService, IMediator mediator)
        {
            _authService = authService;
            _mediator = mediator;
        }

        [Route("change-status")]
        [HttpPost]
        public async Task<ActionResult> ChangeStatus(int userID, UserStatusChangeCommand userStatusChangeCommand)
        {
            if (userID != userStatusChangeCommand.UserId)
            {
                return BadRequest();
            }
            var updatedUser = await _mediator.Send(userStatusChangeCommand);
            return Ok(updatedUser);
        }

        [Route("update-profile")]
        [HttpPost]
        public async Task<ActionResult> UpdateProfile(int userID, UserEditCommand userStatusChangeCommand)
        {
            if (userID != userStatusChangeCommand.UserId)
            {
                return BadRequest();
            }
            var updatedUser = await _mediator.Send(userStatusChangeCommand);
            return Ok(updatedUser);
        }
    }
}
