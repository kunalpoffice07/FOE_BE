using FOA_BE.Models;

namespace FOA_BE.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateOrder(User user);
    }
}
