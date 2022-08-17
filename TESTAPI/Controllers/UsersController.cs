using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryAndUOW.Core;
using RepositoryAndUOW.Core.IRepositories;
using RepositoryAndUOW.Core.Models;
using RepositoryAndUOW.Core.DTO;

namespace RepositoryAndUOW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUnitOfWork uow;

    public UsersController(IUnitOfWork uow) => this.uow = uow;

    #region Users area
    [HttpGet("UsersGetUserById")]
    public IActionResult UsersGetById(int id) => Ok(new UserDTO(uow.Users.GetById(id)));
    [HttpGet("UsersGetAll")]
    public IActionResult UsersGetAll()
    {
        var users = uow.Users.GetAll();
        List<UserDTO> res = new List<UserDTO>();
        foreach (var user in users)
            res.Add(new UserDTO(user));
        return Ok(res);
    }

    [HttpGet("UsersGetByName")]
    public IActionResult UsersGetByName(string name)
    {
        var user = new UserDTO(uow.Users.Find(x => x.FirstName.Contains(name), "Posts"));

        return Ok(user);
    }
    [HttpGet("UsersGetAllByName")]
    public IActionResult UsersGetAllByName(string name)
    {
        var users = uow.Users.FindAll(x => x.FirstName.Contains(name), "Posts");

        List<UserDTO> res = new List<UserDTO>();
        foreach (var user in users)
            res.Add(new UserDTO(user));
        return Ok(res);
    }
    [HttpPost("UsersAddOne")]
    public IActionResult UsersAddOne(UserDTO entity)
    {
        User user = new User(entity);
        uow.Users.Add(user);
        uow.Complete();
        return Ok( new UserDTO(user));
    }
    [HttpGet("UsersGetPosts")]
    public IActionResult UsersGetPosts(int id)
    {
        var posts = uow.Users.PostsOfUser(id);
        List<PostDTO> res = new();
        foreach (var post in posts)
            res.Add(new PostDTO(post));
        return Ok(res);
    }
    #endregion

    #region Posts area

    [HttpGet("PostsGetById")]
    public IActionResult PostsGetById(int id)
        => Ok(new PostDTO(uow.Posts.GetById(id)));

    [HttpGet("PostsFind")]
    public IActionResult PostsFind(int id)
    {
        return Ok(new PostDTO(uow.Posts.Find(p => p.Id == id,"Pictures")));
    }

    [HttpGet("PostsGetAll")]
    public IActionResult PostsGetAll()
    {
        List<PostDTO> res = new();
        var posts = uow.Posts.GetAll();
        foreach (var post in posts)
            res.Add(new PostDTO(post));
        return Ok(res);
    }

    [HttpGet("PostsGetByName")]
    public IActionResult PostsGetByName(string title)
    {
        var post = new PostDTO(uow.Posts.Find(x => x.Title.Contains(title), "User", "Pictures"));
        return Ok(post);
    }

    [HttpGet("PostsFindAll")]
    public IActionResult PostsFindAll(string title)
    {
        var posts = uow.Posts.FindAll(x => x.Title.Contains(title), "User", "Pictures");
        List<PostDTO> res = new();
        foreach (var post in posts)
            res.Add(new PostDTO(post));
        return Ok(res);
    }

    [HttpPost("PostsAddOne")]
    public IActionResult PostsAddOne(CreatePostDTO entity)
    {
        Post post = new(entity);
        uow.Posts.Add(post);
        foreach(var prop in entity.Properties)
        {
            if (uow.PropertyTypes.Find(p => p.Type == prop.Text.Trim()) == null)
                uow.PropertyTypes.Add(new PropertyType { Type = prop.Text });
        }
        var id = uow.Complete();
        return Ok(id);
    }



    [HttpGet("PostsGetViews")]
    public IActionResult PostsGetViews(int id)
        => Ok(uow.Posts.ViewsCount(id));
    #endregion

    #region Pictures area
    
    [HttpPost("PicturesAddToPost")]
    public IActionResult PicturesAddToPost(int id,List<IFormFile> files)
    {
        long size = files.Sum(f => f.Length);
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {
                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", ImageName);
                using (var stream = new FileStream(SavePath, FileMode.Create))
                    formFile.CopyTo(stream);
                Picture p = new Picture { FullPath = SavePath , PostId=id };
                uow.Pictures.Add(p);
                uow.Complete();
            }
        }
        return Ok(new { count = files.Count, size });
    }

    #endregion

    #region Comments area

    [HttpGet("CommentsAddOne")]
    public IActionResult CommentsAddOne(CreateCommentDTO entity)
    {
        Comment comment = new(entity);
        uow.Comments.Add(comment);
        uow.Complete();

        return Ok(new CommentDTO(comment));
    }

    [HttpGet("CommentsGetAll")]
    public IActionResult CommentsGetAll()
    {
        return Ok(uow.Comments.GetAll());
    }
    [HttpGet("CommentsGetUserComments")]
    public IActionResult CommentsGetUserComments(int id)
    {
        return Ok(uow.Users.GetById(id).Comments);
    }
    #endregion

    [HttpGet("PropertyTypesGetAll")]
    public IActionResult PropertyTypesGetAll()
    {
        return Ok(uow.PropertyTypes.GetAll());
    }
}
