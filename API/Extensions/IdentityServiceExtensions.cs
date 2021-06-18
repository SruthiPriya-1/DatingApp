using API.Interfaces;
using API.Data;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {

      public  static IServiceCollection AddIdentityServices(this IServiceCollection services , IConfiguration config )
      {
           services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey  = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]) ),
                 ValidateIssuer =false,
                 ValidateAudience = false
             } ;  
            });
            return services;
      }    
    }
}