using Microservice.Core.Utilities.Security.Jwt;
using MediatR;
using Microservice.Core.Utilities.ReturnData;

namespace UserPortalService.Business.AuthFeature.Queries
{
    public class UserLogingCommandQuery : IRequest<ReturnData<AccessToken>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}