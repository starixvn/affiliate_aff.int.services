using Aff.Int.API.Core.Params;

namespace Aff.Int.API.Core.Admin.Params
{
    public class LoginOnUserParam : BaseParam
    {
        public string SessionId { get; set; }

        public string ServerId { get; set; }
    }
}
