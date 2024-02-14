using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Domain.Entities.User
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string Login { get; set; }

        public string Email { get; set; } = string.Empty;
        [Required]
        public byte[] Password { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public string Token { get; set; }

        public string Role { get; set; }


    }
}
