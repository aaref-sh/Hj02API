using RepositoryAndUOW.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class Property
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Value { get; set; }
    public Post Post { get; set; }
    public int PostId { get; set; }
    public Property()
    {

    }
    public Property(PropertyDTO p)
    {
        Text = p.Text;
        Value = p.Value;
        PostId = p.PostId;
    }
}
