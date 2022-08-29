using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryAndUOW.Core.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "الاسم مطلوب")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "الكنية مطلوبة")]
    public string? LastName { get; set; }

    [Phone(ErrorMessage ="يرجى إدخال رقم هاتف صالح")]
    [Required(ErrorMessage = "رقم الهاتف مطلوب")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "كلمة المرور مطلوبة")]
    [MinLength(6,ErrorMessage ="كلمة المرور يجب ألّا تقل عن 6 محارف")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*\d)(?=.*[^a-zA-Z]).{6,20}$", 
        ErrorMessage = "كلمة المرور يجب أن تكون بين 6 و 20 حرف، خليط من أحرف وأرقام")]
    public string? Password { get; set; }

    [Compare("Password",ErrorMessage ="كلمة المرور وتأكيدها يجب أن تكونا متطابقتين")]
    [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
    public string? ConfirmPassword { get; set; }
}
