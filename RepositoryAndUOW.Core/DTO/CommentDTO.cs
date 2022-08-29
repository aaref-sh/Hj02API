using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.DTO;

public class CommentDTO
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public bool? Edited { get; set; } = false;
    public bool? Deleted { get; set; } = false;
    public CommentDTO()
    {

    }
    public CommentDTO(Comment v)
    {
        Id = v.Id;
        UserId = v.UserId;
        PostId = v.PostId;
        Text = v.Text;
        Date = v.Date;
        Edited = v.Edited;
        Deleted = v.Deleted;
    }
}
public class CreateCommentDTO
{
    public string UserId { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; }
}