using Microsoft.EntityFrameworkCore;
using RepositoryAndUOW.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.EF.Repositories;

public class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    protected ApplicationDbContext context { get; set; }
    public BaseRepository(ApplicationDbContext context) 
        => this.context = context;
    public T GetById(int id) 
        => context.Set<T>().Find(id);

    public IEnumerable<T> GetAll() 
        => context.Set<T>().ToList();

    public T Find(Expression<Func<T, bool>> match, params string[] includes)
    {
        IQueryable<T> query = context.Set<T>();
        foreach (string include in includes)
            query = query.Include(include);
        return query.FirstOrDefault(match);
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> match,params string[] includes)
    {
        IQueryable<T> query = context.Set<T>();
        foreach (string include in includes)
            query = query.Include(include);
        return query.Where(match).ToList();
    }

    public T Add(T entity)
    {
        context.Set<T>().Add(entity);
        return entity;
    }
    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        context.Set<T>().AddRange(entities);
        return entities;
    }

    public T Update(T entity)
    {
        context.Update(entity);
        return entity;
    }

    public void Delete(T entity) 
        => context.Remove(entity);

    public void Attach(T entity)
        => context.Set<T>().Attach(entity);

    public void UpdateAll(IEnumerable<T> entities) 
        => context.UpdateRange(entities);

    public void DeleteAll(IEnumerable<T> entities) 
        => context.RemoveRange(entities);

    public int Count() 
        => context.Set<T>().Count();

    public int Count(Expression<Func<T, bool>> criteria) 
        => context.Set<T>().Count(criteria);
}