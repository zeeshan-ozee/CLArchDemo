using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Exceptions;
using CLArch.Application.Interfaces;
using CLArch.Application.Interfaces.Authentication;
using CLArch.Domain.Entities.Authentication;
using MediatR;

namespace CLArch.Application.Models.Authentication.Query
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
    {
        readonly IUserRepository _userRepository;
        readonly IJwtTokenGenerator _tokenGenerator;
        public LoginQueryHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        {
            _tokenGenerator = tokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new DuplicateEmailException("USer with given email address not found");
            }

            if (request.Password != user.Password)
            {
                throw new WrongCredentialsException("Invalid credentials.");
            }

            //generate jwt
            var token = _tokenGenerator.GenerateToken(user);


            return new AuthenticationResponse
            {
                Id = user.Id,
                Email = request.Email,
                FirstName = "FirstNAME",
                LastName = "lastNAME",
                Token = token
            };
        }


    }
}