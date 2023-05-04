using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.IRepositories;

public interface IBaseRepository<T> 
    where T : class
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    T Find(Expression<Func<T,bool>> match,params string [] includes);
    IEnumerable<T> FindAll(Expression<Func<T,bool>> match,params string [] includes);
    T Add(T entity);
    IEnumerable<T> AddRange(IEnumerable<T> entities);
    T Update(T entity);
    void Delete(T entity);
    void Attach(T entity);
    void UpdateAll(IEnumerable<T> entities);
    void DeleteAll(IEnumerable<T> entities);
    int Count();
    int Count(Expression<Func<T, bool>> criteria);



}
