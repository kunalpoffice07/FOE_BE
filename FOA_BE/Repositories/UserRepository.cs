using FOA_BE.Data;
using FOA_BE.DTOs;
using FOA_BE.Models;
using FOA_BE.Repositories.Interfaces;
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

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<List<GetUserDto>> GetAllUSers()
        {
            var users = await _context.Users.ToListAsync();

            return users.Select(user => new GetUserDto
            {
                Id = user.UserId,
                UserName = user.UserName,
                Phone = user.Phone,
                Email = user.Email,
                Address = user.Address,
            }).ToList();
        }

        public async Task DeleteUser(User user)
        {
            _context.Users.Remove(user);    
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
