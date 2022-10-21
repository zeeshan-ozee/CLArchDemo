using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Exceptions;
using CLArch.Application.Interfaces;
using CLArch.Application.Interfaces.Authentication;
using CLArch.Application.Models.Authentication;
using CLArch.Domain.Entities.Authentication;

namespace CLArch.Application.Services.Authentication
{
    public class AuthenticationQueryService : IAuthenticationQueryService
    {
        readonly IUserRepository _userRepository;
        readonly IJwtTokenGenerator _tokenGenerator;
        public AuthenticationQueryService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }
        public AuthenticationResponse Login(LoginRequest request)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new Exception("USer with given email addre not found");
            }

            if (request.Password != user.Password)
            {
                throw new Exception("Invalid credentials.");
            }
            return new AuthenticationResponse
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = "FirstNAME",
                LastName = "lastNAME",
                Token = Guid.NewGuid().ToString()
            };
        }


    }
}