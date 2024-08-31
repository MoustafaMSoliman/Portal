using Microsoft.EntityFrameworkCore;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.Common.Models;
using System.Linq.Expressions;
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
        _dbContext.SaveChanges();
    }

    public AG Find(Func<AG, bool> match)
    {
        return _dbContext.Set<AG>().FirstOrDefault(match);
    }

    public IEnumerable<AG> FindAll(Func<AG, bool> perdicate)
    {
        return _dbContext.Set<AG>().Where(perdicate);
    }

    public AG FindWithInclue(Func<AG, bool> match, params Expression<Func<AG, object>>[] includeProperties)
    {
        IQueryable<AG> query = _dbContext.Set<AG>();
        foreach (var property in includeProperties) 
        {
            query= query.Include(property);
        }
        return query.FirstOrDefault(match);
    }

    public IEnumerable<AG> GetAll()
    {
        return _dbContext.Set<AG>();
    }

    public AG GetById(AGId id)
    {
        return _dbContext.Set<AG>().SingleOrDefault(a=>a.Id==id);
    }

    public AG GetByIdWithInclude(AGId id, params Expression<Func<AG, object>>[] includeProperties)
    {
        IQueryable<AG> query = _dbContext.Set<AG>();
        foreach(var property in includeProperties)
        { query= query.Include(property); }
        return query.SingleOrDefault(x => x.Id == id);
    }
}
