using Microsoft.AspNetCore.Mvc;
using SiemensEnergy.Library.Application;
using SiemensEnergy.Library.Infrastructure;
using SiemensEnergy.Library.Application.Interfaces;
using SiemensEnergy.Library.Infrastructure.Repositories;
using SiemensEnergy.Library.API;
using FluentValidation.AspNetCore;
using SiemensEnergy.Library.Application.Validators.Livro;
using SiemensEnergy.Library.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning(opt => {
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateLivroDtoValidator>());


// Add repositories interfaces
builder.Services.AddScoped<ILivroRepository, LivroRepository>();

builder.Services.AddScoped<IAutorRepository, AutorRepository>();

builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
