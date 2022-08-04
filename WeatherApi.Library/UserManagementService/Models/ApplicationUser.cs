using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherApi.Library.UserManagementService.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(256)")]
        public string? FirstName { get; set; }

        [Column(TypeName = "nvarchar(256)")]
        public string? LastName { get; set; }
    }
}
