using Aff.Int.API.Core.Admin.Command;
using Aff.Int.API.Core.Admin.Criteria;
using Aff.Int.API.Core.Admin.Criteria.Login;
using Aff.Int.API.Core.Admin.Models;
using Aff.Int.API.Core.Admin.Params;
using Aff.Int.API.Core.Models.DTOs;
using Aff.Int.API.Infrastructure.Constants;
using Fanex.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aff.Int.API.Core.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/auth/[action]")]
    public class AdminAuthController(IDynamicRepository dynamicRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<bool> ReCheckinAsync(int onUserId)
        {
            return await dynamicRepository.GetAsync<bool>(new ReCheckinCriteria { OnUserId = onUserId });
        }

        [HttpPost]
        public async Task<ResultInfo> LoginAsync([FromBody] AdminLoginParam param)
        {
            var criteria = new AdminLoginCriteria()
            {
                UserName = param.UserName,
                Password = param.Password,
                UserHostName = param.UserHostName,
                Ip = param.Ip,
                UserId = param.UserId,
            };

            return await dynamicRepository.GetAsync<ResultInfo>(criteria);
        }

        [HttpGet]
        public async Task<IEnumerable<AdminPermissionModel>> GetAdminPermissionsAsync(int userId)
        {
            return await dynamicRepository.FetchAsync<AdminPermissionModel>(new AdminPermissionCriteria { UserId = userId });
        }

        [HttpGet]
        public async Task<ResultInfo> CheckAdminPermissionAsync(int userId, string funcName)
        {
            var criteria = new CheckAdminPermissionCriteria
            { 
                UserId = userId,
                FuncName = funcName
            };

            return await dynamicRepository.GetAsync<ResultInfo>(criteria);
        }

        [HttpGet]
        public async Task<ResultInfo> Logout(int onUserId)
        {
            try
            {
                await dynamicRepository.ExecuteAsync(new AdminLogoutCommand { OnUserId = onUserId });

                return new ResultInfo();
            }
            catch (Exception ex)
            {
                return new ResultInfo
                {
                    ErrCode = ErrCode.ErrCodeBadGateway,
                    ErrMsg = ex.Message
                };
            }
        }
    }
}