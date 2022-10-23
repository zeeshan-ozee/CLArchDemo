using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Models.Authentication;
using CLArch.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CLArch.Application.Models.Authentication.Commands;
using CLArch.Application.Models.Authentication.Query;
using MapsterMapper;
using CLArch.WebApi.Validations;
using AutoWrapper.Wrappers;

namespace CLArch.WebApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        CancellationTokenSource _cancelTokenSource = null;
        readonly IMediator _mediator;
        readonly IMapper _mapper;
        // readonly IAuthenticationCommandService _authCommandService;
        // readonly IAuthenticationQueryService _authQueryService;
        public AuthenticationController(IMediator mediator, IMapper mapper
            /*IAuthenticationCommandService authService, IAuthenticationQueryService authQueryService*/)
        {
            // _authCommandService = authService;
            // _authQueryService = authQueryService;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken = default)
        {

            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            // RegisterUserRequestValidator validator = new RegisterUserRequestValidator();
            // FluentValidation.Results.ValidationResult result = validator.Validate(request);
            // if (!result.IsValid)
            // {
            //     System.Console.WriteLine("Fluent validation failed");
            //     //return ValidationProblem(ModelState);  //Results.ValidationProblem(result.ToDictionary());
            // }

            System.Console.WriteLine("Fluent validation passed");
            // _cancelTokenSource = new CancellationTokenSource();
            // _cancelTokenSource.CancelAfter(4000);
            // Task.Delay(5000);
            // CancellationToken _token = _cancelTokenSource.Token;
            // if (_token.IsCancellationRequested)
            //     _token.ThrowIfCancellationRequested();


            //return Ok(_authCommandService.Register(request));

            var registerCommand = _mapper.Map<RegisterCommand>(request);
            // new RegisterCommand
            // {

            //     FirstName = request.FirstName,
            //     LastName = request.LastName,
            //     Email = request.Email,
            //     Password = request.Password
            // };

            var registerResult = _mediator.Send(registerCommand, cancellationToken);

            return Ok(registerResult);

            //return new ApiResponse("New record has been created in the database.", registerResult, 200);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken = default)
        {

            //return Ok(_authQueryService.Login(request));

            var loginQuery = _mapper.Map<LoginQuery>(request);
            //new LoginQuery { Email = request.Email, Password = request.Password };
            var loginResult = _mediator.Send(loginQuery, cancellationToken);

            return Ok(loginResult);


        }

    }
}