using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Aff.Int.API.Core.Models
{
    public class TokenRequest
    {
        const int MaxLengthOfUserName = 50;
        const int MaxLengthOfPassword = 16;

        [MaxLength(MaxLengthOfUserName)]
        [Required]
        public string Username { get; set; }

        [MaxLength(MaxLengthOfPassword)]
        [Required]
        public string Password { get; set; }

        public bool IsShowIpvn { get; set; } = true;
    }
}
