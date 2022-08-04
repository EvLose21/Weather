using WeatherApi.Library.UserManagementService.Models;

namespace WeatherApi.Library.UserManagementService.Requests
{
    public class CreateUserRequest
    {
        public ApplicationUser? User { get; set; }

        public string? Password { get; set; }
    }
}
