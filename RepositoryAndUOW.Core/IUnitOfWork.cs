using RepositoryAndUOW.Core.IRepositories;
using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core;

public interface IUnitOfWork : IDisposable
{
    IPostsRepository Posts { get; }
    IUsersRepository Users { get; }
    IBaseRepository<Picture> Pictures { get; }
    IBaseRepository<View> Views { get; }
    IBaseRepository<Like> Likes { get; }
    IBaseRepository<Property> Properties { get; }
    IBaseRepository<PropertyType> PropertyTypes { get; }
    IBaseRepository<Comment> Comments { get; }
    int Complete();

}
