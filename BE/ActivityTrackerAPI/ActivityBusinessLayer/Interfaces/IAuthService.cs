using ActivityDataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ActivityBusinessLayer.Interfaces
{
    public interface IAuthService
    {
        Task<JwtSecurityToken> Login(IdentityUser user);
        Task<IdentityResult> CreateUser(Register model);
        Task<IdentityResult> CreateAdmin(Register model);
    }
}
