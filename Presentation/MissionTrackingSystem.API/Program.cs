using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MissionTrackingSystem.Application;
using MissionTrackingSystem.Application.Validators.Departments;
using MissionTrackingSystem.Infrastructure;
using MissionTrackingSystem.Infrastructure.Filters;
using MissionTrackingSystem.Persistence;
using System.Net.Http;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddCors(options=> options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200","https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddApplicationServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateDepartmentValidator>())
    .ConfigureApiBehaviorOptions(options =>options.SuppressModelStateInvalidFilter=true );

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer("Admin",options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,//olusturalacak token deðerlerini neresi kullanacak belirliyoruz
        ValidateIssuer= true,//oluþturulacak token deðerini kimin daðýttýgýný ýfade eder
        ValidateLifetime= true,//oluþturulan token deðerinin süresini kontrol et
        ValidateIssuerSigningKey= true,//üretilecek token deðerinin uygulamamýza ait deðer ifade eden security key 

        ValidAudience = builder.Configuration["Token:Audience"],
        ValidIssuer = builder.Configuration["Token:Issuer"],
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
