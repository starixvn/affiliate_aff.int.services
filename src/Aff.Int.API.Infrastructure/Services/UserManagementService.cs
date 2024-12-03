using Aff.Int.API.Core.Extensions;
using Aff.Int.API.Core.Models.Options;
using Microsoft.Extensions.Options;

namespace Aff.Int.API.Core.Services
{
    public class UserManagementService(IOptions<List<UserOptions>> userListAccessor) : IUserManagementService
    {
        public bool IsValidUser(string username, string password)
            => userListAccessor.Value.Exists(x => x.UserName.Equals(username)
            && x.Password.Equals(password.Sha256()));
    }
}
