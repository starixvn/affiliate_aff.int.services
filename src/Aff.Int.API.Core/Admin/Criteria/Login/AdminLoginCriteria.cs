using Aff.Int.API.Core.Criteria;

namespace Aff.Int.API.Core.Admin.Criteria.Login
{
    public class AdminLoginCriteria : BaseCriteria
    {
        private const string SP_NAME = "Aff_CustomerSel";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => true;

        public string UserName { get; set; }

        public string Password { get; set; }

        public string UserHostName { get; set; }
    }
}
