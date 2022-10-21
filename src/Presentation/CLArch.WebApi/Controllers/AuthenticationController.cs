using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Models.Authentication;
using CLArch.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CLArch.WebApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        CancellationTokenSource _cancelTokenSource = null;
        readonly IAuthenticationService _authService;
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken token = default)
        {
            // _cancelTokenSource = new CancellationTokenSource();
            // _cancelTokenSource.CancelAfter(4000);
            // Task.Delay(5000);
            // CancellationToken _token = _cancelTokenSource.Token;
            // if (_token.IsCancellationRequested)
            //     _token.ThrowIfCancellationRequested();


            return Ok(_authService.Register(request));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken token = default)
        {
            return Ok(_authService.Login(request));
        }

    }
}