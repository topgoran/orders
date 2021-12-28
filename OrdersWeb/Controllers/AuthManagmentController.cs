using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrdersApp.Data.Models;
using OrdersWeb.Configuration;
using OrdersWeb.DTOs.Create;
using OrdersWeb.DTOs.Read;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagmentController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthManagmentController(UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor) {
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto user) 
        {
            if (ModelState.IsValid) 
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                //AKOK POSTOJI USER SA ISTIM MEJLOM
                if (existingUser != null) 
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Email already in use" },
                        Success = false
                    });
                }
                var newUser = new User()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    City = user.City,
                    State = user.State,
                };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);

                if (isCreated.Succeeded)
                {
                    User userCreated = await _userManager.FindByNameAsync(newUser.UserName);
                    await _userManager.AddToRoleAsync(userCreated, "Member");

                    var jwtToken = GenerateJwtToken(newUser);

                    return Ok(new RegistrationResponse()
                    {
                        Success = true,
                        Token = jwtToken
                    });
                }
                else {
                    //AKO KREIRANJE NIJE USPJELO
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Unable to create user" },
                        Success = false
                    });
                }
            }
            //AKO BODY NIJE DOBRO FORMIRAN
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() { "Invalid payload" },
                Success = false
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user) 
        {
            if (ModelState.IsValid) 
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);
                if (existingUser == null) {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Invalid login request" },
                        Success = false
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
                if (!isCorrect) {
                    return BadRequest(new RegistrationResponse()
                    {
                        Errors = new List<string>() { "Invalid login request" },
                        Success = false
                    });
                }


                var jwtToken = GenerateJwtToken(existingUser);
                return Ok(new RegistrationResponse()
                {
                    Success = true,
                    Token = jwtToken
                });

            }
            return BadRequest(new RegistrationResponse()
            {
                Errors = new List<string>() { "Invalid payload" },
                Success = false
            });
        }

        private String GenerateJwtToken(User user) {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    //new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
