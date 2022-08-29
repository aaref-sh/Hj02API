using Microsoft.AspNetCore.Mvc;
using RepositoryAndUOW.Core;
using RepositoryAndUOW.Core.DTO;
using RepositoryAndUOW.Core.Models;
using System.Net.Http.Headers;

namespace RepositoryAndUOW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PicturesController : ControllerBase
{
    private readonly IUnitOfWork uow;
    public PicturesController(IUnitOfWork uow) => this.uow = uow;
    [HttpGet("GetImageById")]
    public IActionResult GetImageById(int id)
    {
        var pic = uow.Pictures.GetById(id).FullPath;
        var file = System.IO.File.ReadAllBytes(pic);
        return File(file, "image/jpeg");
    }
    [HttpPost("UploadAsync"), DisableRequestSizeLimit]
    public IActionResult OnPostUploadAsync(List<IFormFile> files,int id)
    {
        long size = files.Sum(f => f.Length);
        foreach (var formFile in files)
        {
            if (formFile.Length > 0)
            {

                string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);

                //Get url To Save
                string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pictures", ImageName);

                using (var stream = new FileStream(SavePath, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
                Picture p = new();
                p.FullPath = SavePath;
                uow.Pictures.Add(p);
                uow.Complete();
            }
        }
        return Ok(new { count = files.Count, size });
    }

    [HttpPost("upload")]
    public IActionResult upload(CreatePostDTO entity)
    {
        Post post = new(entity);
        uow.Posts.Add(post);
        var id = uow.Complete();
        return Ok(id);
    }
}
