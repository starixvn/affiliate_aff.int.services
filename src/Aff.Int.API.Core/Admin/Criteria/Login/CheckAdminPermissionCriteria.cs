using Aff.Int.API.Core.Admin.Constants;
using Fanex.Data;
using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Admin.Criteria.Login
{
    public class CheckAdminPermissionCriteria : CriteriaBase
    {
        private const string SP_NAME = "Aff_Admin_PolicySel";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => UserId > 0 && Array.Exists(Function.SupportedFunctionNames, f => string.Equals(f, FuncName, StringComparison.OrdinalIgnoreCase));

        [SpParam(SqlParamName = "CustId")]
        public int UserId { get; set; }

        public string FuncName { get; set; }
    }
}
