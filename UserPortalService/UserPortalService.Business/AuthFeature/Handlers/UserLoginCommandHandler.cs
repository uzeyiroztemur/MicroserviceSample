using MediatR;
using Microservice.Core.Utilities.ReturnData;
using Microservice.Core.Utilities.ReturnData.Enum;
using Microservice.Core.Utilities.Security.Jwt;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.AuthFeature.Queries;
using UserPortalService.Business.Utilities.Security.Hasing;

namespace UserPortalService.Business.AuthFeature.Handlers
{
    public class UserLoginCommandHandler : IRequestHandler<UserLogingCommandQuery, ReturnData<AccessToken>>
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserLoginCommandHandler(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<ReturnData<AccessToken>> Handle(UserLogingCommandQuery command, CancellationToken cancellationToken)
        {
            var userToCheck = await _userService.GetUserByMail(command.Email);
            if (userToCheck == null || userToCheck.Data == null)
            {
                return new ReturnData<AccessToken> { Data = null, Status = ReturnDataStatusEnum.Error, Message = "Incorrect email or password" };
            }

            if (!HashingHelper.VerifyPasswordHash(command.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ReturnData<AccessToken> { Data = null, Status = ReturnDataStatusEnum.Error, Message = "Incorrect email or password" };
            }

            var res = await _authService.CreateAccessToken(userToCheck.Data);
            return res;
        }
    }
}