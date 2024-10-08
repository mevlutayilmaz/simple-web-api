﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentPortalAPI.Application.Abstractions.Tokens;
using StudentPortalAPI.Application.DTOs;
using StudentPortalAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Infrastructure.Services.Tokens
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenDTO CreateAccessToken(int second, AppUser user)
        {
            TokenDTO token = new();
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"])); //SecurityKey in simetriğini alıyoruz
            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256); //Şifrelenmiş kimliği oluşturuyoruz
            
            token.Expiration = DateTime.UtcNow.AddSeconds(second);
            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow, //Token ne zaman aktif olsun. (hemen)
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) });

            JwtSecurityTokenHandler securityTokenHandler = new(); //Token oluşturucu sınıfı
            token.AccessToken = securityTokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();
            
            return token;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }
}
