using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.DTO;

public class PropertyDTO
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string Value { get; set; }
    public Guid PostId { get; set; }
    public PropertyDTO()
    {

    }
    public PropertyDTO(Property p)
    {
        Text = p.Text;
        Value = p.Value;
        PostId = p.PostId;
    }
}
