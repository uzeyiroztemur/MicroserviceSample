using System.Reflection;
using System.Text;
using MediatR;
using Microservice.Core.Utilities.Exceptions;
using Microservice.Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using UserPortalService.Business.Abstract;
using UserPortalService.Business.AuthFeature.Handlers;
using UserPortalService.Business.Concrete.Managers;
using UserPortalService.Business.Utilities.Security.Jwt;
using UserPortalService.DataAccess.Abstract;
using UserPortalService.DataAccess.Concrete.EntityFramework;
using UserPortalService.DataAccess.Concrete.EntityFramework.Context;
using UserPortalService.RestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Swagger
builder.Services.AddSwaggerGen((options) =>
{
    options.SwaggerGeneratorOptions.IgnoreObsoleteActions = true;

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
});


// AddDependencyResolvers islemi
builder.Services.AddTransient<IUserService, UserManager>();
builder.Services.AddTransient<IUserDal, EfUserDal>();
builder.Services.AddTransient<IAuthService, AuthManager>();
builder.Services.AddTransient<ITokenHelper, JwtHelper>();
builder.Services.AddDbContext<UserPortalDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"));
});

builder.Services.AddGrpc();

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
    };
});

//Routing
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//MediatR
builder.Services.AddMediatR(typeof(UserRegisterCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UserLoginCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UserStatusChangeCommandHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UserEditCommandHandler).GetTypeInfo().Assembly);

var app = builder.Build();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGrpcService<UserService>();
});

app.MapControllers();

// global error handler
app.UseMiddleware<ExceptionHandlingMiddleware>();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

app.Run();
