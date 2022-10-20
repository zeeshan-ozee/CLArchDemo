using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CLArch.Application.Interfaces.Authentication;
using CLArch.Domain.Entities.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CLArch.Infrastructure.Authentication
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;

    }
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        readonly JwtSettings _jwtSettings;
        readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }
        public string GenerateToken(Guid userId, string firstName, string lastName)
        {

            System.Console.WriteLine("Generating token");
            System.Console.WriteLine($"configs are {_jwtSettings.Secret}");

            //symmetric key as we are both issuer and validator of the key
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256



            );
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: siginingCredentials
                 );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public string GenerateToken(User user)
        {
            return GenerateToken(user.Id, user.FirstName, user.LastName);
        }


    }


    public class JwtSettings
    {
        public const string Section_Name = "JwtSettings";
        public string Secret { set; get; }
        public int ExpiryMinutes { set; get; }
        public string Issuer { set; get; }
        public string Audience { set; get; }
    }
}