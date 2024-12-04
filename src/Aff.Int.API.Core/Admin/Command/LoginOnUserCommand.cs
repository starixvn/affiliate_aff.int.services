using Aff.Int.API.Core.Admin.Constants;
using Fanex.Data;
using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Admin.Command
{
    public class LoginOnUserCommand : NonQueryCommand
    {
        private const string SP_NAME = "Aff_CheckIn";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => true;

        [SpParam(SqlParamName = "NetSessionId")]
        public string SessionId { get; set; }

        [SpParam(SqlParamName = "CustId")]
        public int UserId { get; set; }

        public string ServerId { get; set; }

        public string Ip { get; set; }

        public int SubAccId { get; } = SystemSetting.SubAccId_AdminSite;

        [SpParam(SqlParamName = "On_UserId")]
        public int OnUserId { get; set; }
    }
}
