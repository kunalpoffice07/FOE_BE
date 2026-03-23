using FOA_BE.DTOs;
using FOA_BE.Models;

namespace FOA_BE.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUser(UserDto userDto);
        Task<GetUserDto> GetUserById(Guid id);
        Task<List<GetUserDto>> GetAllUsers();
        Task DeleteUserById(Guid id);
        Task UpdateUser(Guid id, UpdateUserDto updateUserDto);
        Task UpdateUserByAdmin(Guid id, AdminUpdateUserDto adminUpdateUserDto);

    }
}
