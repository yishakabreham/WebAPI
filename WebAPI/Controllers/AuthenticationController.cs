using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SDA_Core.Entities;
using WebAPI.DataServices;
using WebAPI.Dtos;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        IDataManager _dataManager;
        IConfiguration _configuration;
        public AuthenticationController(IDataManager dataManager, IConfiguration config)
        {
            _dataManager = dataManager;
            _configuration = config;
        }

        [HttpPost("loginuser")]
        public async Task<IActionResult> Login(LoginData login)
        {
            if(login == null || string.IsNullOrWhiteSpace(login.username) || string.IsNullOrWhiteSpace(login.password))
            {
                return Unauthorized();
            }

            var user = await _dataManager.GetUserByUserName(login.username);
            if(user == null)
            {
                return Unauthorized();
            }

            var encriptedPass = Helper.Encrypt(login.password);
            if (string.IsNullOrWhiteSpace(encriptedPass) || encriptedPass != user.Password)
            {
                return Unauthorized();
            }

            var validToken = GenerateToken(new User { UserName = login.username });
            var company = await _dataManager.GetOwnCompany();
            return Ok(new 
            {
                approved = 1,
                token = validToken,
                user = new {
                    id = user.Code,
                    name = string.Format("{0} {1} {2}", user.PersonNavigation.FirstName, user.PersonNavigation.MiddleName, user.PersonNavigation.LastName),
                    dob = user.PersonNavigation.Dob.Value.ToString(TICKET2020Constants.dateFormat),
                    title = user.PersonNavigation.TitleNavigation.Description,
                    gender = user.PersonNavigation.GenderNavigation.Description,
                    position = user.PersonNavigation.PositionNavigation.Description,
                    isActive = user.PersonNavigation.IsActive
                },
                company = new { 
                    tradeName = company?.TradeName,
                    brandName = company?.BrandName
                }
            });
        }

        [Authorize]
        [HttpGet("getValues")]
        public IActionResult getValues()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = identity.Claims.ToList();
            var userName = claims[0].Value;
            return Ok("Ok to " + userName);
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentialsa = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            { 
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentialsa);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}
