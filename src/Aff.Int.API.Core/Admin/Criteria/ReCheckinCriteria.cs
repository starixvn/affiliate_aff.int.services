using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Admin.Criteria
{
    public class ReCheckinCriteria : CriteriaBase
    {
        private const string SP_NAME = "Aff_CheckIn";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => OnUserId > 0;

        public int OnUserId { get; set; }
    }
}
