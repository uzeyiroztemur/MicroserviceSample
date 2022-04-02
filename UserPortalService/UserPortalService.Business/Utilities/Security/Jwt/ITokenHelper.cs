using UserPortalService.Entities.Models;
using Microservice.Core.Utilities.Security.Jwt;
using System.Collections.Generic;

namespace UserPortalService.Business.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> operationClaims);
    }
}