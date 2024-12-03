using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Admin.Criteria.Login
{
    public class AdminPermissionCriteria : CriteriaBase
    {
        private const string SP_NAME = "Aff_Admin_PolicySel";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => UserId > 0;

        public int UserId { get; set; }
    }
}
