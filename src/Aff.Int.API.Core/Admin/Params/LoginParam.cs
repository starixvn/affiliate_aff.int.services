
using Aff.Int.API.Core.Params;

namespace Aff.Int.API.Core.Admin.Params
{
    public class LoginParam : BaseParam
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string UserHostName { get; set; }
    }
}
