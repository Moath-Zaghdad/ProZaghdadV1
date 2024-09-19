using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ProZaghdadV1.Controllers
{
    public abstract class ProZaghdadV1ControllerBase: AbpController
    {
        protected ProZaghdadV1ControllerBase()
        {
            LocalizationSourceName = ProZaghdadV1Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
