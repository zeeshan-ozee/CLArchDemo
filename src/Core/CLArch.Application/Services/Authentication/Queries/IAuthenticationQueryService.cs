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
    // public class AuthenticationResult
    // {
    //     public Guid Id { get; set; }
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public string Email { get; set; }
    //     public string Token { get; set; }
    // }
    public interface IAuthenticationQueryService
    {
        AuthenticationResponse Login(LoginRequest request);
        
    }
}