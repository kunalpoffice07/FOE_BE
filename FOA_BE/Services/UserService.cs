using FOA_BE.DTOs;
using FOA_BE.Models;
using FOA_BE.Repositories.Interfaces;
using FOA_BE.Services.Interfaces;
using System.Runtime.InteropServices;

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
            await _userRepository.SaveChangesAsync();

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
                throw new Exception("User not found");
            }

            await _userRepository.DeleteUser(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
            {
                throw new Exception("User not found");
            }

            user.UserName = updateUserDto.UserName ?? user.UserName;
            user.Phone = updateUserDto?.Phone ?? user.Phone;
            user.Email = updateUserDto?.Email ?? user.Email;
            user.Address = updateUserDto?.Address ?? user.Address;

            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserByAdmin(Guid id, AdminUpdateUserDto adminUpdateUserDto)
        {
            var user = await _userRepository.GetUserById(id);

            if (user is null)
            {
                throw new Exception("User not found");
            }

            user.UserName = adminUpdateUserDto.UserName ?? user.UserName;
            user.Phone = adminUpdateUserDto.Phone ?? user.Phone;
            user.Address = adminUpdateUserDto.Address ?? user.Address;

            await _userRepository.SaveChangesAsync();
        }

    }
}
