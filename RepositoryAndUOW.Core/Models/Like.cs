using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class Like
{
    public int Id { get; set; }
    public Post Post { get; set; }
    public User User { get; set; }
}
