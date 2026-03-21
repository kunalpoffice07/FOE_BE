using static FOA_BE.Enum.Enumeration;

namespace FOA_BE.DTOs
{
    public class UserResponseDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string UserRole { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
