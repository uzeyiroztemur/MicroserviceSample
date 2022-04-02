using UserPortalService.Entities.Models;
using Microservice.Core.Utilities.Security.Jwt;
using System.Threading.Tasks;
using UserPortalService.Entities.Dtos;
using Microservice.Core.Utilities.ReturnData;

namespace UserPortalService.Business.Abstract
{
    public interface IAuthService
    {
        Task<ReturnData<AccessToken>> CreateAccessToken(User user);

        Task<ReturnData<User>> RegisterUser(User user);

        Task<ReturnData<User>> LoginUser(UserForLoginDto userForLoginDto);
    }
}