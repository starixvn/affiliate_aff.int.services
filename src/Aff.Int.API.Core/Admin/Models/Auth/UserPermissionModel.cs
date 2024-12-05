
using System.Text.Json.Serialization;

namespace Aff.Int.API.Core.Admin.Models.Auth
{
    public class UserPermissionModel
    {
        [JsonPropertyName("FunctionName")]
        public string FuncName { get; set; }

        [JsonPropertyName("IsHost")]
        public bool Host { get; set; }
    }
}
