using GraphQL;
using GraphQL.Validation;
using Microsoft.AspNetCore.Identity;
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

namespace OrdersWeb.GraphQL
{
    public class RegistrationRepository
    {
        public async Task<RegistrationResponse> registration(UserCreateDto user, UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, String role) {
            UserManager<User> _userManager = userManager;
            JwtConfig _jwtConfig = optionsMonitor.CurrentValue;

            var existingUser = await _userManager.FindByEmailAsync(user.Email);

            RegistrationResponse registrationResponse = new RegistrationResponse()
            {
                Success = false,
                Token = ""
            };

            //AKO POSTOJI USER SA ISTIM MEJLOM
            if (existingUser != null)
            {
                throw new ExecutionError("User with this email already exists");
            }

            //AKO POSTOJI USER SA ISTIM USERNAME
            existingUser = await _userManager.FindByNameAsync(user.UserName);

            if (existingUser != null)
            {
                throw new ExecutionError("User with this username already exists.");
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
                await _userManager.AddToRoleAsync(userCreated, role);

                registrationResponse.Success = true;
                return registrationResponse;
            }
            else
            {
                throw new ExecutionError("Password did not meet the requirements");
            }
        }

        public async Task<User> LogIn(UserManager<User> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, string userName, string password)
        {
            UserManager<User> _userManager = userManager;
            JwtConfig _jwtConfig = optionsMonitor.CurrentValue;

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) {
                throw new ExecutionError("Username doesn't exist");
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, password);
            if (!passwordCheck) {
                throw new ExecutionError("Wrong password");
            }


            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            foreach (var r in roles)
                if (await _userManager.IsInRoleAsync(user, r.ToString()))
                {
                    claims.Add(new Claim(ClaimTypes.Role, r.ToString()));
                }

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken("Invenit", "Tokens:Issuer",
                claims,
                expires: DateTime.Now.AddHours(24),
                signingCredentials: creds);

            user.Token = new JwtSecurityTokenHandler().WriteToken(secToken);
            return user;
        }
    }
}
