using Microsoft.IdentityModel.Tokens;
using OnlineVotingSystem.Entities.RequestEntity;
using OnlineVotingSystem.Entities.ResponseEntity;
using OnlineVotingSystem.Managers.Interface;
using OnlineVotingSystem.Model;
using OnlineVotingSystem.Repositories.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineVotingSystem.Managers.Manager
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;

        public UserManager(IUserRepository userRepo, IConfiguration configuration)
        {
            _userRepo = userRepo;
            _configuration = configuration;
        }

        public async Task<CommonResponse> Signup(UserSignupRequest request)
        {
            var existingUser = await _userRepo.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new CommonResponse
                {
                    status_code = 400,
                    message = "Email already exists",
                    status = "Error"
                };
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await _userRepo.AddUserAsync(user);

            return new CommonResponse
            {
                status_code = 200,
                message = "User registered successfully",
                status = "Success",
                data = new { user.Id, user.Name, user.Email, user.Role }
            };
        }

        public async Task<CommonResponse> Login(UserLoginRequest request)
        {
            var user = await _userRepo.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return new CommonResponse
                {
                    status_code = 401,
                    message = "Invalid email or password",
                    status = "Error"
                };
            }

            var token = GenerateJwtToken(user);

            return new CommonResponse
            {
                status_code = 200,
                message = "Login successful",
                status = "Success",
                data = new { token }
            };
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
