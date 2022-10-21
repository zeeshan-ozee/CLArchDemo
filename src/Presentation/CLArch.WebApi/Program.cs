using CLArch.Application;
using CLArch.Application.Models.Authentication;
using CLArch.Application.Models.Authentication.Commands;
using CLArch.Infrastructure;
using CLArch.Persistance;
using CLArch.WebApi.Mapping;
using CLArch.WebApi.Middleware;
using Mapster;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication(builder.Configuration);
    builder.Services.AddPersistance(builder.Configuration);
    builder.Services.AddInfrastrcture(builder.Configuration);
    builder.Services.AddPresentation(builder.Configuration);

    // TypeAdapterConfig<RegisterRequest, RegisterCommand>.NewConfig();
    // TypeAdapterConfig<RegisterRequest, LoginRequest>.NewConfig();
    //.Map(dest => dest.FullName, src => $"{src.Title} {src.FirstName} {src.LastName}");




}
var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    //app.UseAuthorization();

    app.MapControllers();

    app.Run();
}