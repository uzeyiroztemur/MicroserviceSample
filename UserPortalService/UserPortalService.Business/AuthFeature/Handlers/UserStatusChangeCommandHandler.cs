using MediatR;
using Microservice.Core.Utilities.ReturnData;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.AuthFeature.Commands;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.AuthFeature.Handlers
{
    public class UserStatusChangeCommandHandler : IRequestHandler<UserStatusChangeCommand, ReturnData<User>>
    {
        private readonly IUserService _userService;

        public UserStatusChangeCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ReturnData<User>> Handle(UserStatusChangeCommand request, CancellationToken cancellationToken)
        {
            var userInfo = await _userService.UserInfo(request.UserId);

            userInfo.Data.Status = request.ChangedStatus;
            userInfo.Data.ModifiedBy = request.UserId;
            userInfo.Data.ModifiedOn = DateTime.Now;

            var res = await _userService.Edit(userInfo.Data);
            return res;
        }
    }
}