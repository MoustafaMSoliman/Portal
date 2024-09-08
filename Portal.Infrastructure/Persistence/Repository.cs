using Microsoft.EntityFrameworkCore;
using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.Common.Models;
using Portal.Domain.User;
using System.Linq;
using System.Linq.Expressions;

namespace Portal.Infrastructure.Persistence;

public class Repository<T, I> : IRepository<T, I> where T : Entity<I> where I : class
{
    //private readonly List<T> _list= new();
    private readonly PortalDbContext _dbContext;
    public Repository(PortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddNew(T t)
    {
        _dbContext.Add(t);
        _dbContext.SaveChanges();   
    }

    public T Find(Func<T, bool> match) => _dbContext.Set<T>().FirstOrDefault(match);

    
    public IEnumerable<T> FindAll(Func<T,bool> match) => _dbContext.Set<T>().Where(match);

    public IEnumerable<T> FindAllWithInclude(Func<T, bool> predicate, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        foreach (var property in includeProperties)
        {
            query = query.Include(property);
        }
        return query.Where(predicate);
    }

    public T FindWithInclue(Func<T, bool> match, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _dbContext.Set<T>();
        foreach (var property in includeProperties)
        {

            query = query.Include(property);
        }

        return query.FirstOrDefault(match);
    }

    public IEnumerable<T> GetAll() => _dbContext.Set<T>();
   

    public T GetById(I id) => _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);

    public T GetByIdWithInclude(I id, params Expression<Func<T, object>>[] includeProperties)
    {
       IQueryable<T> query = _dbContext.Set<T>();
        foreach(var property in includeProperties)
        { query = query.Include(property); }
        return query.SingleOrDefault(x=>x.Id==id);

    }

    public void Remove(T t)
    {
        _dbContext.Set<T>().Remove(t);
        
    }

    public void Update(T t)
    {
        _dbContext.Attach(t);   
        _dbContext.Set<T>().Update(t);
    }
}
