using Fanex.Data;
using Fanex.Data.Repository;

namespace Aff.Int.API.Core.Criteria
{
    public abstract class PagingCriteria : CriteriaBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalPages { get; set; }

        [SpParam(SqlParamName = "NRows")]
        public int TotalItem { get; set; }
    }
}
