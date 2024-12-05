using Aff.Int.API.Core.Models.DTOs;

namespace Aff.Int.API.Core.Admin.Models.Auth
{
    public class LoginModel : ResultInfo
    {
        public int UserId { get; set; }
    }
}
