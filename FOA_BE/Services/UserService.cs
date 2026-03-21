using FOA_BE.DTOs;
using FOA_BE.Models;
using FOA_BE.Repositories.Interfaces;
using FOA_BE.Services.Interfaces;

namespace FOA_BE.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<UserResponseDto> CreateUser(UserDto userDto)
        {
            _logger.LogInformation($"Creating the user in {nameof(UserService)}");

            var existingUser = await _userRepository.GetUserByEmail(userDto.Email);

            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Phone = userDto.Phone,
                Address = userDto.Address,
                CreatedAt = DateTime.UtcNow
            };

            var userResponseDto = await _userRepository.CreateOrder(user);

            return new UserResponseDto
            {
                UserId = userResponseDto.UserId,
                UserName = userResponseDto.UserName,
                Email = userResponseDto.Email,
                Phone = userResponseDto.Phone,
                Address = userResponseDto.Address,
                UserRole = userResponseDto.UserRole.ToString(),
                CreatedAt = userResponseDto.CreatedAt
            };
        }

        public async Task<GetUserDto?> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user is null)
            {
                return null;
            }

            return new GetUserDto
            {
                Id = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
            };
        }


        public async Task<List<GetUserDto>> GetAllUsers()
        {
            return await _userRepository.GetAllUSers();
        }

        public async Task DeleteUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                throw new Exception("User doesnot exists");
            }

          await _userRepository.DeleteUser(user);          

        }
        public async Task UpdateUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                throw new Exception("User doesnot exists");
            }



        }
    }
}
