using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.DTO;

public class PictureDTO
{
    public int Id { get; set; }
    public string FullPath { get; set; }
    public int PostId { get; set; }

    public PictureDTO() { }
    public static explicit operator PictureDTO(Picture v)
    {
        PictureDTO picture = new();
        picture.Id = v.Id;
        picture.FullPath = v.FullPath;
        picture.PostId = v.PostId;
        return picture;
    }
    public PictureDTO(Picture v)
    {
        Id = v.Id;
        FullPath = v.FullPath;
        PostId = v.PostId;
    }
}
