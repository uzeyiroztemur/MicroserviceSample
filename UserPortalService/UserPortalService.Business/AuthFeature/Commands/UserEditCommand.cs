using MediatR;
using Microservice.Core.Utilities.ReturnData;
using UserPortalService.Entities.Models;

namespace UserPortalService.Business.AuthFeature.Commands
{
    public class UserEditCommand : IRequest<ReturnData<User>>
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
