using FOA_BE.DTOs;
using FOA_BE.Models;

namespace FOA_BE.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDto userDto);
        Task<GetUserDto> GetUserById(Guid id);
    }
}
