using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Criteria
{
    public abstract class BaseCriteria : CriteriaBase
    {
        public int UserId { get; set; }

        public string Ip { get; set; }
    }
}
