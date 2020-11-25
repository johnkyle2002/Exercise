using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Exercise.Model
{
    public class ApplicationUser: IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(750)]
        public string LastName { get; set; }
    }

    public class ApplicationRole: IdentityRole
    {

    }
}
