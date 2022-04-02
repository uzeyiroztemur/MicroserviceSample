using System;

namespace Microservice.Core.Entities
{
    public interface IModifable
    {
        DateTime? ModifiedOn { get; set; }
        int? ModifiedBy { get; set; }
    }
}