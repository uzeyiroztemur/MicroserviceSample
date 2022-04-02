using Microservice.Core.DataAccess.EntityFramework;
using UserPortalService.DataAccess.Abstract;
using UserPortalService.DataAccess.Concrete.EntityFramework.Context;
using UserPortalService.Entities.Models;

namespace UserPortalService.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, UserPortalDbContext>, IUserDal
    {
        public List<Role> GetClaims(User user)
        {
            using var context = new UserPortalDbContext();
            var result = from uoc in context.UserRole
                         join oc in context.Role on uoc.RoleId equals oc.Id
                         where uoc.UserId == user.Id
                         select new Role { Id = oc.Id, Name = oc.Name };
            return result.ToList();
        }
    }
}