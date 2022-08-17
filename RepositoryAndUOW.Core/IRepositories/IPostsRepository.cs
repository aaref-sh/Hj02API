using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.IRepositories;

public interface IPostsRepository : IBaseRepository<Post>
{
    int ViewsCount (int id);
}
