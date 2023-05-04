using RepositoryAndUOW.Core.Models;
using RepositoryAndUOW.Core.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.DTO;

public class PostDTO
{
    public Guid Id { get; set; }
    public UserDTO? User { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public PostState State { get; set; }
    public string Title { get; set; }
    public City City { get; set; }
    public string PostBody { get; set; }
    public int Views { get; set; }
    public int Likes { get; set; }

    public double Price { get; set; } = 0;
    public double? DiscountPrice { get; set; } = 0;
    public string Created { get; set; }
    public string Edited { get; set; }
    public ICollection<PictureDTO>? Pictures { get; set; }
    public ICollection<PropertyDTO>? Properties { get; set; }
    public ICollection<Tag>? Tags { get; set; }

    public PostDTO()
    {

    }
    public PostDTO(Post v)
    {
        List<PictureDTO> pictures = new();
        List<PropertyDTO> properties = new();
        if(v.Pictures != null)
            foreach (var picture in v.Pictures)
                pictures.Add(new PictureDTO(picture));

        if(v.Properties != null)
            foreach (var p in v.Properties)
                properties.Add(new PropertyDTO(p));

        Id = v.Id;
        PostBody = v.PostBody;
        Title = v.Title;
        City = v.City;
        Price = v.Price;
        DiscountPrice = v.DiscountPrice;
        Created = v.Created.ToString("yyyy/MM/dd HH:mm");
        Edited = v.Edited?.ToString("yyyy/MM/dd HH:mm") ?? "";
        State = v.State;
        UserId = v.UserId;
        UserName = v.User.FirstName + " " + v.User.LastName; 
        Pictures = pictures;
        Properties = properties;
        Views = v.Views.Count;
        Likes = v.Likes.Count;

    }

}

public class PostInListDTO
{

    public Guid Id { get; set; }
    public UserDTO? User { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Title { get; set; }
    public City City { get; set; }
    public int Views { get; set; }
    public int Likes { get; set; }
    public string Picture { get; set; }
    public double Price { get; set; } = 0;
    public double? DiscountPrice { get; set; } = 0;
    public string Date { get; set; }
    public ICollection<Tag>? Tags { get; set; }

    public PostInListDTO()
    {

    }
    public PostInListDTO(Post v)
    {
        Id = v.Id;
        Title = v.Title;
        City = v.City;
        Price = v.Price;
        DiscountPrice = v.DiscountPrice;
        Date = v.Edited?.ToString("yyyy/MM/dd HH:mm")??v.Created.ToString("yyyy/MM/dd HH:mm");
        UserId = v.UserId;
        UserName = v.User.FirstName + " " + v.User.LastName;
        Views = v.Views.Count;
        Likes = v.Likes.Count;
        Picture = v.Pictures.Any()?v.Pictures.ElementAt(0).FullPath:"";
        if (v.Tags is not null)
        {
            Tags = v.Tags; 
        }

    }
}

public class CreatePostDTO
{
    public string UserId { get; set; }
    public string Title { get; set; }
    public City City { get; set; }
    public string PostBody { get; set; }
    public double Price { get; set; } = 0;
    public double? DiscountPrice { get; set; } = 0;
    public ICollection<PropertyDTO>? Properties { get; set; }
    public ICollection<Tag>? Tags { get; set; }
}