using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sunglass_ecom.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity.Data;
using System;
using Sunglass_ecom.Data;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;


using System.Text;
using System.Text.Json.Serialization;

namespace Sunglass_ecom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly EcommerceDbContext _dbContext;
        private readonly IConfiguration _configuration;


        // Constructor to inject AppDbContext
        public RegistrationController(EcommerceDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Registration(User registration)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.NameIdentifier, registration.Id.ToString()),
                        new Claim(ClaimTypes.Name, registration.Username),
                        new Claim(ClaimTypes.Role, registration.Role)
                    };
                    Console.WriteLine(_configuration["ApplicationSettings:JWT_Secret"]);

                    var jwtToken = new JwtSecurityToken(
                        claims: claims,
                        notBefore: DateTime.UtcNow,
                        expires: DateTime.UtcNow.AddDays(0.1),
                        signingCredentials: new SigningCredentials(
                            new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"])
                            ),
                        SecurityAlgorithms.HmacSha256Signature));
                    var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                    var response = new
                    {
                        userName = registration.Username,
                        token = token
                    };

                    await _dbContext.Set<User>().AddAsync(registration);
                    await _dbContext.SaveChangesAsync();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            try
            {
                // Check if the user exists in the database
                var user = _dbContext.Users
                    .FirstOrDefault(u => u.Username == loginDto.Username);

                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Verify the password
                if (user.Password != loginDto.Password)
                {
                    return Unauthorized("Invalid password.");
                }

                // Login successful
                return Ok(new { Message = "Login successful", User = user });
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



    }


}

