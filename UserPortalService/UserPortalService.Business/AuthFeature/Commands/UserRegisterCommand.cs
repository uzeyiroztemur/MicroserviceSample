using MediatR;
using Microservice.Core.Utilities.ReturnData;

namespace UserPortalService.Entities.AuthFeature.Commands
{
    public class UserRegisterCommand : IRequest<ReturnData<int>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}