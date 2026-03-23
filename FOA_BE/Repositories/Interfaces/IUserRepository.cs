using FOA_BE.DTOs;
using FOA_BE.Models;

namespace FOA_BE.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateOrder(User user);
        Task<User> GetUserById(Guid id);
        Task<User?> GetUserByEmail(string email);
        Task<List<GetUserDto>> GetAllUSers();
        Task DeleteUser(User user);
        Task UpdateUser(User user);
        Task SaveChangesAsync();
    }
}
