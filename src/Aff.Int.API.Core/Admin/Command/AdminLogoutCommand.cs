using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Admin.Command
{
    public class AdminLogoutCommand : NonQueryCommand
    {
        private const string SP_NAME = "Aff_Logout";

        public int OnUserId { get; set; }

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => OnUserId > 0;
    }
}
