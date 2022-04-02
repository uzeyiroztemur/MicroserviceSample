using UserPortalService.Entities.Models;
using Microservice.Core.DataAccess;
using System.Collections.Generic;

namespace UserPortalService.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<Role> GetClaims(User user);
    }
}