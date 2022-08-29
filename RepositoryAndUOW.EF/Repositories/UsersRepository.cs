using RepositoryAndUOW.Core.IRepositories;
using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.EF.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(ApplicationDbContext context) : base(context)
    {
    }

    public List<Post> PostsOfUser(string userId)
    {
        return Find(x => x.Id == userId,"Posts").Posts.ToList();
    }
}
