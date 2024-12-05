using Aff.Int.API.Core.Admin.Criteria.Home;
using Aff.Int.API.Core.Admin.Models.Home;
using Aff.Int.API.Core.Models.DTOs;
using Fanex.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aff.Int.API.Core.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/[controller]/[action]")]
    public class HomeController(IDynamicRepository dynamicRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<EntityResult<UserOnlineModel>> GetUserOnlineListAsync(int pageIndex, int pageSize)
        {
            var criteria = new UserOnlineCriteria
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
            };

            var userOnlineList = await dynamicRepository.FetchAsync<UserOnlineModel>(criteria);

            return new EntityResult<UserOnlineModel>
            {
                TotalItem = criteria.TotalItem,
                MainData = userOnlineList
            };
        }

        [HttpGet]
        public async Task<GeneralInfoModel> GetGeneralInfoAsync()
        {
            return await dynamicRepository.GetAsync<GeneralInfoModel>(new GeneralInfoCriteria());
        }
    }
}