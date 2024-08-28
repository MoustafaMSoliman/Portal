using Portal.Domain.Common.Models;
using Portal.Domain.User;
using System.Linq.Expressions;

namespace Portal.Application.Common.Interfaces.Persistence;

public interface IRepository<TId, TIdType> where TId : class where TIdType : notnull
{
    TId GetById(TIdType id);
   
    TId Find(Func<TId, bool> match);
    void AddNew(TId t);
    IEnumerable<TId> GetAll();
    IEnumerable<TId> FindAll(Func<TId,bool> perdicate);
}

