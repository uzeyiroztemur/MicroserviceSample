using System;

namespace Microservice.Core.Entities
{
    public interface ICreatable
    {
        DateTime CreatedOn { get; set; }
        int CreatedBy { get; set; }
    }
}