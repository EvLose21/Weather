using Microsoft.AspNetCore.Identity;

namespace WeatherApi.Library.UserManagementService.Responses
{
    public class IdentityResultDto
    {
        public bool Succeeded { get; set; }

        public IEnumerable<IdentityError> Errors { get; set; }
    }
}
