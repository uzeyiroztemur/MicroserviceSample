using Microservice.Core.Utilities.ReturnData;
using Microservice.Core.Utilities.ReturnData.Enum;
using UserPortalService.Business.Abstract;
using UserPortalService.DataAccess.Abstract;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public ReturnData<List<Role>> GetClaims(User user)
        {
            var result = new ReturnData<List<Role>>();
            try
            {
                result.Data = _userDal.GetClaims(user);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ReturnDataStatusEnum.Error;
            }
            return result;
        }

        public async Task<ReturnData<User>> GetUserByMail(string email)
        {
            var result = new ReturnData<User>();
            try
            {
                result.Data = await _userDal.GetAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ReturnDataStatusEnum.Error;
            }
            return await Task.FromResult(result);            
        }

        public async Task<ReturnData<User>> Created(User user)
        {
            var result = new ReturnData<User>();
            try
            {
                result.Data = await _userDal.AddAsync(user);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ReturnDataStatusEnum.Error;
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnData<User>> Login(string email, string password)
        {
            return await Task.FromResult(await GetUserByMail(email));
        }

        public async Task<ReturnData<User>> Edit(User user)
        {
            var result = new ReturnData<User>();
            try
            {
                result.Data = await _userDal.UpdateAsync(user);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ReturnDataStatusEnum.Error;
            }
            return await Task.FromResult(result);
        }

        public async Task<ReturnData<User>> UserInfo(int userId)
        {
            var result = new ReturnData<User>();
            try
            {
                result.Data = await _userDal.GetAsync(u => u.Id == userId);
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = ReturnDataStatusEnum.Error;
            }
            return await Task.FromResult(result);
        }
    }
}