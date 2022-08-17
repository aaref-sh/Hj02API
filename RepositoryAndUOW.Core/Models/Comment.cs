using RepositoryAndUOW.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class Comment
{
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    public int UserId { get; set; }
    [ForeignKey("PostId")]
    public Post Post { get; set; }
    public int PostId { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public bool? Edited { get; set; } = false;
    public bool? Deleted { get; set; } = false;
    public Comment()
    {

    }
    public Comment(CreateCommentDTO v)
    {
        UserId = v.UserId;
        PostId = v.PostId;
        Text = v.Text;
    }
    public Comment(CommentDTO v)
    {
        Id = v.Id;
        UserId = v.UserId;
        PostId = v.PostId;
        Text = v.Text;
        Edited = true;
        Date = DateTime.Now;
    }
}
