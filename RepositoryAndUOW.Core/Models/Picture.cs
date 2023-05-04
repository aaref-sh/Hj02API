using RepositoryAndUOW.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class Picture
{

    public Guid Id { get; set; }
    public string FullPath { get; set; }
    public Post Post { get; set; }
    public Guid PostId { get; set; }
    public Picture(PictureDTO p)
    {
        FullPath = p.FullPath;
    }
    public Picture()
    {

    }
}
