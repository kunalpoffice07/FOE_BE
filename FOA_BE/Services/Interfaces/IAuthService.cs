using FOA_BE.DTOs;

namespace FOA_BE.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto loginDto);

    }
}
