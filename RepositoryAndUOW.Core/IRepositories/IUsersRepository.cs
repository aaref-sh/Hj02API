using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.IRepositories;

public interface IUsersRepository : IBaseRepository<User>
{
    List<Post> PostsOfUser(string userId);
}
