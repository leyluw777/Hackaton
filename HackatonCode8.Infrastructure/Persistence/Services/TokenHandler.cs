using HackatonCode8.Application.Common.JWT;
using HackatonCode8.Application.DTOs;
using HackatonCode8.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HackatonCode8.Infrastructure.Persistence.Services
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;

        readonly UserManager<AppUser> _userManager;


		public TokenHandler(IConfiguration configuration, UserManager<AppUser> userManager)
		{
			_configuration = configuration;
            _userManager = userManager;
			
		}
		public async Task<TokenDto> CreateAccessToken(int second, AppUser appUser)
        {
            TokenDto token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                 claims:await  SetClaims(appUser),
                signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);


            return token;
        }
        private async  Task<IEnumerable<Claim>> SetClaims(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
		
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

            if (!string.IsNullOrEmpty(user.UserName))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                claims.Add(new Claim(ClaimTypes.Role, userRoles[0]));

                
            }
            return claims;
        }
    }
    }
