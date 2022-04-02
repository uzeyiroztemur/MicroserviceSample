using Microservice.Core.Utilities.ApiServices;
using Microservice.Core.Utilities.Caching.Redis;
using Microservice.Core.Utilities.MessageQueue.RabbitMq;
using Microservice.Core.Utilities.Security.Jwt;

namespace Microservice.Core.Entities
{
    public class BaseOptions
    {
        public Redis Redis { get; set; }
        public TokenOptions TokenOptions { get; set; }
        public RabbitMq RabbitMq { get; set; }
        public Service[] Services { get; set; }
    }
}