using FOA_BE.Data;
using FOA_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FOA_BE.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly AppDbContext _context;

        public UserRepository(ILogger<UserRepository> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<User> CreateOrder(User user)
        {       
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;

        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
