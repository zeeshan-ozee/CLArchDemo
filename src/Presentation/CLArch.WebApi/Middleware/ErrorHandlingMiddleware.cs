using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CLArch.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CLArch.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;


        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }

        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            System.Console.WriteLine("Exception handled by middleware");
            var code = HttpStatusCode.InternalServerError;

            var problemDetail = new ProblemDetails
            {

                Title = "An error occured while processing your request",
                Status = (int)code,
                Detail = ex.Message,
                Type = "https://RFC:500",

            };
            if (ex is DuplicateEmailException)
            {

                problemDetail.Title = "Duplicate email address already exists";
                problemDetail.Status = (int)HttpStatusCode.Ambiguous;
            }

            problemDetail.Extensions["traceId"] = Guid.NewGuid();

            var result = JsonConvert.SerializeObject(problemDetail); // JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}