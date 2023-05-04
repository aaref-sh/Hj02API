using RepositoryAndUOW.Core.DTO;
using RepositoryAndUOW.Core.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class Post
{
    public Guid Id { get; set; }
    public User? User { get; set; }
    public string UserId { get; set; }
    public PostState State { get; set; } = PostState.Pinding;

    [Required, MaxLength(150)]
    public string Title { get; set; }
    public City City { get; set; }
    public string PostBody { get; set; }
    public bool Deleted { get; set; } = false;
    public double Price { get; set; } = 0;
    public double? DiscountPrice { get; set; } = 0;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Edited { get; set; } = null;
    public ICollection<Picture>? Pictures { get; set; }
    public ICollection<Property> Properties { get; set; }
    public virtual ICollection<Like>? Likes { get; set; }
    public virtual ICollection<View>? Views { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }


    public Post() { }
    public Post(CreatePostDTO v)
    {
        List<Property> properties = new();
        List<Tag> tags = new();
        if(v.Properties is not null)
        {
            foreach (var p in v.Properties)
            { 
                properties.Add(new Property(p)); 
            }
        }
        if (v.Tags is not null)
        {
            foreach (var tag in v.Tags)
            {
                tags.Add(tag);
            }
        }

        UserId = v.UserId;
        Title = v.Title;
        City = v.City;
        PostBody = v.PostBody;
        Price = v.Price;
        DiscountPrice = v.DiscountPrice;
        Properties = properties;
        Tags = tags;
    }
}
