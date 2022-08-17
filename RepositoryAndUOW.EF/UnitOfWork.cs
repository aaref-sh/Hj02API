using RepositoryAndUOW.Core;
using RepositoryAndUOW.Core.IRepositories;
using RepositoryAndUOW.Core.Models;
using RepositoryAndUOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.EF;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext context;

    public IUsersRepository Users { get; private set; }
    public IPostsRepository Posts { get; private set; }
    public IBaseRepository<Picture> Pictures { get; private set; }
    public IBaseRepository<Property> Properties { get; private set; }
    public IBaseRepository<PropertyType> PropertyTypes { get; private set; }
    public IBaseRepository<Like> Likes { get; private set; }
    public IBaseRepository<View> Views { get; private set; }
    public IBaseRepository<Comment> Comments { get; private set; }
    public UnitOfWork(ApplicationDbContext context)
    {
        this.context = context;

        Users = new UsersRepository(context);
        Posts = new PostsRepository(context);
        Pictures = new BaseRepository<Picture>(context);
        Likes = new BaseRepository<Like>(context);
        Views = new BaseRepository<View>(context);
        Comments = new BaseRepository<Comment>(context);
        Properties = new BaseRepository<Property>(context);
        PropertyTypes = new BaseRepository<PropertyType>(context);
    }

    public int Complete() => context.SaveChanges();

    public void Dispose() => context.Dispose();
}
