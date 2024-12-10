using Microsoft.IdentityModel.Tokens;
using PersonRegistrationSystem.DataBase.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PersonRegistrationSystem.Services
{
    public interface IJwtService
    {
        string JwtToken(User user);
    }
    public class JwtService: IJwtService
    {
        private readonly IConfiguration _configuration; 
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string JwtToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
               
            };
            var secretToken = _configuration.GetSection("Jwt:Key").Value;
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretToken));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: cred);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

   
}
