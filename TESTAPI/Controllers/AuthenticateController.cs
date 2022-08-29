using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RepositoryAndUOW.Core.Models;

namespace RepositoryAndUOW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticateController : ControllerBase
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthenticateController(
        SignInManager<User> signInManager,
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.PhoneNumber);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var res = await _signInManager.PasswordSignInAsync(model.PhoneNumber, model.Password, isPersistent: model.RememberMe, false);
            if (res.Succeeded)
            {
                if (user.IsActive != 1)
                {
                    return Ok(new Response { Success=false, Icon="warning" , Message="حسابك غير مفعل"});
                }
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    success = true,
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    Id = user.Id,
                    expiration = token.ValidTo
                });
            }
        }
        return Unauthorized(new Response { Success=false, Icon="warning-circle" , Message="خطأ في اسم المستخدم أو كلمة المرور"});
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.PhoneNumber);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success=false, Icon = "warning", Message = "رقم الهاتف مسجل بالفعل! استخدم رقم آخر" });

        User user = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.PhoneNumber
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            var res = (from x in result.Errors select x.Description).ToArray();
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success=true, Icon = "warning", array = res });
        }
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        await _userManager.AddToRoleAsync(user, UserRoles.User);

        return Ok(new Response { Success=true, Icon = "check", Message = "تم إنشاء الحساب" });
    }

    [HttpPost]
    [Route("register-admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.PhoneNumber);
        if (userExists != null)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Icon = "warning", Message = "رقم الهاتف مسجل بالفعل! استخدم رقم آخر" });

        User user = new()
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.PhoneNumber
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Icon = "warning", Message = "User creation failed! Please check user details and try again." });

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));


        await _userManager.AddToRoleAsync(user, UserRoles.Admin);
        await _userManager.AddToRoleAsync(user, UserRoles.User);

        return Ok(new Response { Success=true, Icon = "check", Message = "User created successfully!" });
    }
    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        return token;
    }
}
