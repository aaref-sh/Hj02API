using RepositoryAndUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int ReportedTimes { get; set; }
    public DateTime LastLogin { get; set; }

    public UserDTO(User v)
    {
        Id = v.Id;
        FirstName = v.FirstName;
        LastName = v.LastName;
        PhoneNumber = v.PhoneNumber;
        ReportedTimes = v.ReportedTimes;
        LastLogin = v.LastLogin;
    }
    public UserDTO() { }
}
