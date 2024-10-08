﻿using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ProZaghdadV1.Configuration.Dto;

namespace ProZaghdadV1.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ProZaghdadV1AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
