using System.Text.Json.Serialization;

namespace Aff.Int.API.Core.Admin.Models.Home
{
    public class UserOnlineModel
    {
        public string UserName { get; set; }

        [JsonPropertyName("LoggedInDate")]
        public DateTime? LoggedIn { get; set; }

        [JsonPropertyName("LastRequestDate")]
        public DateTime? LastRequest { get; set; }

        public string Ip { get; set; }

        [JsonPropertyName("Role")]
        public string RoleName { get; set; }
    }
}
