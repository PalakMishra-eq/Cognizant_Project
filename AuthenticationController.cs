using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login(LoginRequestDto request)
    {
        // Authenticate user based on credentials
        bool isAuthenticated = AuthenticateUser(request.Username, request.Password);

        if (!isAuthenticated)
        {
            return Unauthorized();
        }

        // Generate JWT token
        string token = GenerateJwtToken(request.Username);

        return Ok(new { Token = token });
    }

    private bool AuthenticateUser(string username, string password)
    {
        // Perform authentication logic, such as checking credentials against the database
        // Return true if authentication is successful, false otherwise
        // You can use your data access layer to perform database operations here
        // Example pseudo code: return userRepository.Authenticate(username, password);
        return true;
    }

    private string GenerateJwtToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
