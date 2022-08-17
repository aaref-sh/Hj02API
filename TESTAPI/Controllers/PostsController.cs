using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryAndUOW.Core;
using RepositoryAndUOW.Core.DTO;
using RepositoryAndUOW.Core.IRepositories;
using RepositoryAndUOW.Core.Models;

namespace RepositoryAndUOW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IUnitOfWork uow;

    public PostsController(IUnitOfWork uow) 
        => this.uow = uow;

}
