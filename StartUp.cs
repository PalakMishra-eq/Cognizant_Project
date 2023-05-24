using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

public class Startup
{
    private readonly string _jwtSecretKey = "your_secret_key_here";

    public void ConfigureServices(IServiceCollection services)
    {
        // Other configuration code...

        // Configure JWT authentication
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your_issuer_here",
                    ValidAudience = "your_audience_here",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey))
                };
            });

        // Other configuration code...
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Other configuration code...

        app.UseAuthentication();
        app.UseAuthorization();

        // Other configuration code...
    }
}
