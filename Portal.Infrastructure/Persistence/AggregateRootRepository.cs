using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.Common.Models;

namespace Portal.Infrastructure.Persistence;

public class AggregateRootRepository<AG, AGId, AGIdType> : IAggregateRootRepository<AG, AGId, AGIdType>
        where AG : AggregateRoot<AGId, AGIdType>
        where AGId : AggregateRootId<AGIdType>
{
    private readonly List<AG> _list = new();
    public void AddNew(AG t)
    {
        _list.Add(t);
    }

    public AG Find(Func<AG, bool> match)
    {
        return _list.SingleOrDefault(match);
    }

    public IEnumerable<AG> GetAll()
    {
        return _list;
    }

    public AG GetById(AGId id)
    {
        return _list.SingleOrDefault(a=>a.Id==id);
    }
}
