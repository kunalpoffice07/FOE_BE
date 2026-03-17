using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using static FOA_BE.Enum.Enumeration;

namespace FOA_BE.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }

        [Column("user_phone")]
        public string Phone { get; set; }

        [Column("user_email")]
        public string Email { get; set; }

        [Column("user_password")]
        public string Password { get; set; }

        [Column("user_address")]
        public string Address {  get; set; }

        [Column("user_created_at")]
        public DateTime CreatedAt { get; set; } 

        [Column("user_role")]
        public USER_ROLE UserRole { get; set; } 
    }
}
