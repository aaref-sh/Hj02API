using RepositoryAndUOW.Core.IRepositories;
using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.EF.Repositories;

public class PostsRepository : BaseRepository<Post>, IPostsRepository
{

    public PostsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public int ViewsCount(int id) => context.Posts.FirstOrDefault(x => x.Id == id).Views.Count;
}
