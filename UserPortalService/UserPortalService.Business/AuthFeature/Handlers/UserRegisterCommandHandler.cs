using MediatR;
using Microservice.Core.Utilities.ReturnData;
using Microservice.Core.Utilities.ReturnData.Enum;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.Utilities.Security.Hasing;
using UserPortalService.Entities.AuthFeature.Commands;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.AuthFeature.Handlers
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, ReturnData<int>>
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserRegisterCommandHandler(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public async Task<ReturnData<int>> Handle(UserRegisterCommand command, CancellationToken cancellationToken)
        {
            var userToCheck = await _userService.GetUserByMail(command.Email);
            if (userToCheck != null && userToCheck.Data != null)
            {
                return new ReturnData<int> { Data = 0, Status = ReturnDataStatusEnum.Error, Message = "This Email Address Already Used, Please use a different email address" };
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(command.Password, out passwordHash, out passwordSalt);

            var createdUser = await _authService.RegisterUser(new User
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedOn = DateTime.Now,                 
            });

            return new ReturnData<int> { Data = createdUser.Data.Id };
        }
    }
}