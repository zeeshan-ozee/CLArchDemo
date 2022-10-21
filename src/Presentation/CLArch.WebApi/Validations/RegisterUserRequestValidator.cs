using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Models.Authentication;
using FluentValidation;

namespace CLArch.WebApi.Validations
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterUserRequestValidator()
        {
            System.Console.WriteLine("In fluent validation.");

            RuleFor(c => c.FirstName)
            .NotNull()
            .NotEmpty()
            //.Equal("abc@hotmail.com")
            .When(x => x.LastName == "abcxyz")
            .WithMessage("Please provide correct first name");
        }
    }
}