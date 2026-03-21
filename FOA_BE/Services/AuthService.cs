using FOA_BE.DTOs;
using FOA_BE.Jwt;
using FOA_BE.Repositories.Interfaces;
using FOA_BE.Services.Interfaces;

namespace FOA_BE.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly JwtTokenGenerator _jwtTokenGenerator;


        public AuthService(IUserRepository userRepository, JwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmail(loginDto.UserEmail);

            if (user == null)
            {
                throw new Exception("Invalid Credentials");
            }

            bool valid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password);

            if (!valid)
            {
                throw new Exception("Invalid credentials");
            }

            return _jwtTokenGenerator.GenerateToken(user);
        }
    }
}
