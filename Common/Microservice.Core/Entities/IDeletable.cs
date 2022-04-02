using System;

namespace Microservice.Core.Entities
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
        int? DeletedBy { get; set; }
    }
}