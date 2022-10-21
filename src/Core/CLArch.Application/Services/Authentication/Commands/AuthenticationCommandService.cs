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
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        readonly IUserRepository _userRepository;
        readonly IJwtTokenGenerator _tokenGenerator;
        public AuthenticationCommandService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }


        public AuthenticationResponse Register(RegisterRequest request)
        {

            //check if user exists
            System.Console.WriteLine("in register method");
            //check if user does not exists
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                throw new DuplicateEmailException("User exists.");
            }

            //create user
            var user = new User
            {

                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password
            };
            _userRepository.AddUser(user);

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