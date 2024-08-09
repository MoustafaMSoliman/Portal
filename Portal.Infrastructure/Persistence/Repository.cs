using Portal.Application.Common.Interfaces.Persistence;
using Portal.Domain.Common.Models;
using Portal.Domain.User;
using System.Linq;
using System.Linq.Expressions;

namespace Portal.Infrastructure.Persistence;

public class Repository<T, I> : IRepository<T, I> where T : Entity<I> where I : class
{ 
    private readonly List<T> _list= new();

    public void AddNew(T t)
    {
        _list.Add(t);
    }

    public T Find(Func<T, bool> match)
    {
        return _list.SingleOrDefault(match);
        
    }

    public IEnumerable<T> GetAll()
    {
        return _list;
    }

    public T GetById(I id)
    {
        
        return _list.SingleOrDefault(e => e.Id == id);

    }
}
