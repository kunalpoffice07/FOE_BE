using FOA_BE.DTOs;
using FOA_BE.Models;
using FOA_BE.Repositories;

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

        public async Task<User> CreateUser(UserDto userDto)
        {
           _logger.LogInformation($"Creating the user in {nameof(UserService)}");

            var user = new User
            {
                UserId = new Guid(),
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password,    
                Phone = userDto.Phone,
                Address = userDto.Address,  
                CreatedAt = DateTime.UtcNow    
            };

            return await _userRepository.CreateOrder(user);
        }
    }
}
