using Microservice.Core.Utilities.ReturnData;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.Abstract
{
    public interface IUserService
    {
        ReturnData<List<Role>> GetClaims(User user);

        Task<ReturnData<User>> GetUserByMail(string email);

        Task<ReturnData<User>> Created(User user);

        Task<ReturnData<User>> Login(string email, string password);

        Task<ReturnData<User>> Edit(User user);

        Task<ReturnData<User>> UserInfo(int userId);
    }
}