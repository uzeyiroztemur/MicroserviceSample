using UserPortalService.Entities.Models;
using MediatR;
using Microservice.Core.Utilities.ReturnData;

namespace UserPortalService.Business.AuthFeature.Commands
{
    public class UserStatusChangeCommand : IRequest<ReturnData<User>>
    {
        public int UserId { get; set; }
        public bool ChangedStatus { get; set; }
    }
}