using Portal.Domain.Common.Models;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IAggregateRootRepository<AG,AGId, AGIdType> : IRepository<AG, AGId>
    where AG : AggregateRoot<AGId, AGIdType>
    where AGId : AggregateRootId<AGIdType>
{
}
