using Aff.Int.API.Core.Admin.Command;
using Aff.Int.API.Core.Admin.Criteria;
using Aff.Int.API.Core.Admin.Criteria.Login;
using Aff.Int.API.Core.Admin.Models.Login;
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
    [Route("api/admin/[controller]/[action]")]
    public class AuthController(IDynamicRepository dynamicRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<bool> ReCheckinAsync(int onUserId)
        {
            return await dynamicRepository.GetAsync<bool>(new ReCheckinCriteria { OnUserId = onUserId });
        }

        [HttpPost]
        public async Task<LoginModel> LoginAsync([FromBody] LoginParam param)
        {
            var command = new LoginCommand()
            {
                UserName = param.UserName,
                Password = param.Password,
                UserHostName = param.UserHostName,
                Ip = param.Ip
            };

            await dynamicRepository.ExecuteAsync(command);

            return new LoginModel
            {
                UserId = command.UserId,
                ErrCode = command.ErrCode,
                ErrMsg = command.ErrMsg
            };
        }

        [HttpGet]
        public async Task<IEnumerable<UserPermissionModel>> GetUserPermissionsAsync(int userId)
        {
            return await dynamicRepository.FetchAsync<UserPermissionModel>(new UserPermissionCriteria { UserId = userId });
        }

        [HttpGet]
        public async Task<ResultInfo> CheckUserPermissionAsync(int userId, string funcName)
        {
            var criteria = new CheckUserPermissionCriteria
            {
                UserId = userId,
                FuncName = funcName
            };

            return await dynamicRepository.GetAsync<ResultInfo>(criteria);
        }

        [HttpPost]
        public async Task<int> GetOnUserIdAsync([FromBody] LoginOnUserParam param)
        {
            var command = new LoginOnUserCommand
            {
                UserId = param.UserId,
                Ip = param.Ip,
                SessionId = param.SessionId,
                ServerId = param.ServerId
            };

            await dynamicRepository.ExecuteAsync(command);

            return command.OnUserId;
        }

        [HttpPost]
        public async Task<ResultInfo> LogoutAsync(int onUserId)
        {
            try
            {
                await dynamicRepository.ExecuteAsync(new LogoutCommand { OnUserId = onUserId });

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