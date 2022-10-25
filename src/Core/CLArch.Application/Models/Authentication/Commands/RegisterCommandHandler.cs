using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Exceptions;
using CLArch.Application.Interfaces;
using CLArch.Application.Interfaces.Authentication;
using CLArch.Domain.Entities.Authentication;
using MediatR;

namespace CLArch.Application.Models.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
    {
        readonly INotificationService _notificationService;
        readonly IJwtTokenGenerator _jwtTokenGenerator;
        readonly IUserRepository _userRepository;
        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository iUserRepo,
        INotificationService notificationService)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = iUserRepo;
            _notificationService = notificationService;
        }

        public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            System.Console.WriteLine("in register method");
            //check if user does not exists
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                // return Errors.User.DuplicateEmail;
                throw new DuplicateEmailException(DuplicateEmailException.ExMessage);
            }

            var user = new User
            {

                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Password = command.Password
            };
            //create user (generate unqiue Id)
            _userRepository.AddUser(user);


            //create token 
            user.Id = Guid.NewGuid();

            var token = _jwtTokenGenerator.GenerateToken(user);

            await _notificationService.SendInvitationViaEmailAsync("Notification sender===> ", user.Email, "System@sys,com");

            return new AuthenticationResponse(user.Id, user.FirstName, user.LastName, user.Email, token);
        }
    }
}