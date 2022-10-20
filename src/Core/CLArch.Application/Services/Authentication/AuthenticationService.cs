using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces.Authentication;
using CLArch.Application.Models.Authentication;

namespace CLArch.Application.Services.Authentication
{
    // public class AuthenticationResult
    // {
    //     public Guid Id { get; set; }
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public string Email { get; set; }
    //     public string Token { get; set; }
    // }
    public interface IAuthenticationService
    {
        AuthenticationResponse Login(LoginRequest request);
        AuthenticationResponse Register(RegisterRequest request);
    }
    public class AuthenticationService : IAuthenticationService
    {

        readonly IJwtTokenGenerator _tokenGenerator;
        public AuthenticationService(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }
        public AuthenticationResponse Login(LoginRequest request)
        {
            //if (_userRepository.GetUserByEmail(email))
            return new AuthenticationResponse
            {
                Id = Guid.NewGuid(),
            Email = request.Email,
                FirstName = "FirstNAME",
                LastName = "lastNAME",
                Token = Guid.NewGuid().ToString()
            };
        }

        public AuthenticationResponse Register(RegisterRequest request)
        {

            //check if user exists
            //create user
            //generate token

            Guid userId = Guid.NewGuid();
            var token = _tokenGenerator.GenerateToken(userId, request.FirstName, request.LastName);

            return new AuthenticationResponse
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Token = token
            };
        }
    }
}