using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace etradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        readonly private IConfiguration _configuration;
        readonly private IUserWriteRepository _userWriteRepository;

        public AuthController(IConfiguration configuration, IUserWriteRepository userWriteRepository)
        {
            _configuration = configuration;
            _userWriteRepository = userWriteRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePasswordHash(request.Passowrd, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userWriteRepository.AddAsync(new()
            {
                Id = request.Id,
                UserName = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
            await _userWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            if (user.UserName != request.UserName)
            {
                return BadRequest("User not found or Wrong UserName !");
            }

            if (!VerifyPasswordHash(request.Passowrd, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong Passowrd");
            }

            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
    }
}