using Aff.Int.API.Core.Criteria;

namespace Aff.Int.API.Core.Admin.Criteria.Home
{
    public class UserOnlineCriteria : PagingCriteria
    {
        private const string SP_NAME = "Aff_UserOnlineList";

        public override string GetSettingKey() => SP_NAME;

        public override bool IsValid() => PageIndex > 0 && PageSize > 0;
    }
}
