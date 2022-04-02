using Microservice.Core.Utilities.ReturnData;
using Microservice.Core.Utilities.ReturnData.Enum;
using Microservice.Core.Utilities.Security.Jwt;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.Utilities.Security.Jwt;
using UserPortalService.Entities.Dtos;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.Concrete.Managers
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public async Task<ReturnData<AccessToken>> CreateAccessToken(User user)
        {
            var result = new ReturnData<AccessToken>();
            try
            {
                var claims = _userService.GetClaims(user).Data;
                var accessToken = _tokenHelper.CreateToken(user, claims);

                result.Data = accessToken;
            }
            catch (Exception ex)
            {
                result.Data = null;
                result.Status = ReturnDataStatusEnum.Error;
                result.Message = ex.Message;
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnData<User>> RegisterUser(User user)
        {            
            return await _userService.Created(user);
        }

        public async Task<ReturnData<User>> LoginUser(UserForLoginDto userForLoginDto)
        {
            return await _userService.Login(userForLoginDto.Email, userForLoginDto.Password);
        }
    }
}