using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MissionTrackingSystem.Application.Abstractions.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionTrackingSystem.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
       readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Application.DTOs.Token CreateAccessToken(int minute)
        {
            Application.DTOs.Token token = new();

            // Şifrelenmiş Kimliği Oluşturuyoruz
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            // Şifrelenmiş Kimliği Oluşturuyoruz
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            // Oluşturulacak token ayarları
            token.Expiration = DateTime.UtcNow.AddMinutes(minute);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires:token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials:signingCredentials
                );

            // Token oluşturucu sınıfından bir örnek alalım 
            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken= tokenHandler.WriteToken(securityToken);
            return token;
        }
    }
}
