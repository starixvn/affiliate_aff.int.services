using Fanex.Data;
using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Admin.Command
{
    public class LoginCommand : NonQueryCommand
    {
        private const string SP_NAME = "Aff_Admin_Login";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => true;

        public string UserName { get; set; }

        [SpParam(SqlParamName = "UserPwd")]
        public string Password { get; set; }

        [SpParam(SqlParamName = "HostName")]
        public string UserHostName { get; set; }

        public string Ip { get; set; }

        public int UserId { get; set; }

        public int ErrCode { get; set; }

        public string ErrMsg { get; set; }
    }
}
