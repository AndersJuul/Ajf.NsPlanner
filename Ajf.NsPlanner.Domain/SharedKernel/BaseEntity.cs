using System;
using System.Collections.Generic;

namespace Ajf.NsPlanner.Domain.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; protected set; }

        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}