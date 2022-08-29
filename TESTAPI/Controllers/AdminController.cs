using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryAndUOW.Core;
using RepositoryAndUOW.Core.Models;

namespace RepositoryAndUOW.API.Controllers;

[Authorize(Roles = UserRoles.Admin)]
[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IUnitOfWork uow;

    public AdminController(IUnitOfWork uow) => this.uow = uow;

    [HttpPost("UsersActive")]
    public IActionResult UsersActive(string id)
    {
        var user = uow.Users.Find(u => u.Id == id);
        user.IsActive = 1;
        return Ok("User Activated");
    }


}
