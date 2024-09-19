using Abp.Authorization;
using ProZaghdadV1.Authorization.Roles;
using ProZaghdadV1.Authorization.Users;

namespace ProZaghdadV1.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
