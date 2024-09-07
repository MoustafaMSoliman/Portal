using Portal.Domain.Common.Models;
using Portal.Domain.User;
using System.Linq.Expressions;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IRepository<TId, TIdType> where TId : class where TIdType : notnull
{
    TId GetById(TIdType id);
    TId GetByIdWithInclude(TIdType id, params Expression<Func<TId, object>>[] includeProperties);
    TId Find(Func<TId, bool> match);
    TId FindWithInclue(Func<TId, bool> match, params Expression<Func<TId, object>>[] includeProperties);
    void AddNew(TId t);
    IEnumerable<TId> GetAll();
    IEnumerable<TId> FindAll(Func<TId,bool> perdicate);
    IEnumerable<TId> FindAllWithInclude(Func<TId,bool> predicate, params Expression<Func<TId,object>>[] includeProperties);
}

