using RepositoryAndUOW.Core.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class User
{
    public int Id { get; set; }
    [Required, MaxLength(150)]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int ReportedTimes { get; set; } = 0;
    public int IsActive { get; set; } = 0;
    public DateTime LastLogin { get; set; } = DateTime.Now;
    public ICollection<Post> Posts { get; set; }
    public virtual ICollection<Like> Likes { get; set; }
    public virtual ICollection<View> Views { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }

    public User() { }
    public User(UserDTO entity)
    {
        FirstName = entity.FirstName;
        LastName = entity.LastName;
        PhoneNumber = entity.PhoneNumber;
    }
}
