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
    public int Id { get; set; }
    public UserDTO? User { get; set; }
    public int UserId { get; set; }
    public PostState State { get; set; }
    public string Title { get; set; }
    public City City { get; set; }
    public string PostBody { get; set; }

    public double Price { get; set; } = 0;
    public double? DiscountPrice { get; set; } = 0;
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime? Edited { get; set; } = null;
    public ICollection<PictureDTO>? Pictures { get; set; }
    public ICollection<PropertyDTO>? Properties { get; set; }

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
        Created = v.Created;
        Edited = v.Edited;
        State = v.State;
        UserId = v.UserId;
        Pictures = pictures;
        Properties = properties;


    }

}

public class CreatePostDTO
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public City City { get; set; }
    public string PostBody { get; set; }
    public double Price { get; set; } = 0;
    public double? DiscountPrice { get; set; } = 0;
    public ICollection<PropertyDTO>? Properties { get; set; }
}