using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.Common.Models;
using System.Text.RegularExpressions;

namespace Portal.Infrastructure.Persistence;

public class AggregateRootRepository<AG, AGId, AGIdType> : IAggregateRootRepository<AG, AGId, AGIdType>
        where AG : AggregateRoot<AGId, AGIdType>
        where AGId : AggregateRootId<AGIdType>
{
    //private readonly List<AG> _list = new();
    private readonly PortalDbContext _dbContext;

    public AggregateRootRepository(PortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddNew(AG t)
    {
        _dbContext.Set<AG>().Add(t);
    }

    public AG Find(Func<AG, bool> match)
    {
        return _dbContext.Set<AG>().SingleOrDefault(match);
    }

    public IEnumerable<AG> FindAll(Func<AG, bool> perdicate)
    {
        return _dbContext.Set<AG>().Where(perdicate);
    }

    public IEnumerable<AG> GetAll()
    {
        return _dbContext.Set<AG>();
    }

    public AG GetById(AGId id)
    {
        return _dbContext.Set<AG>().SingleOrDefault(a=>a.Id==id);
    }
}
