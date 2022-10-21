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
            RuleFor(c => c.Email).NotNull().Equal("abc@hotmail.com").When(x => x.FirstName != "abcxyz");
        }
    }
}