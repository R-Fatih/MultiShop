using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MultiShop.IdentityServer.Tools
{
    public static class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));
            if (!string.IsNullOrEmpty(model.Username))
                claims.Add(new Claim("Username", model.Username));
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.ExpiryInMinutes);
            JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience,claims: claims, notBefore: DateTime.UtcNow,expires: expireDate,signingCredentials: signingCredentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(token);
            return new TokenResponseViewModel
            {
                Token = tokenString,
                ExpireDate = expireDate
            };
        }
    }
}
