using Microsoft.AspNetCore.Identity;

namespace TaskList.Authentification
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}