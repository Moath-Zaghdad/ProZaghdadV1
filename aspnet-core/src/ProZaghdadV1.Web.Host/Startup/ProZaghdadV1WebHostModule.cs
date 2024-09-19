using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProZaghdadV1.Configuration;

namespace ProZaghdadV1.Web.Host.Startup
{
    [DependsOn(
       typeof(ProZaghdadV1WebCoreModule))]
    public class ProZaghdadV1WebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ProZaghdadV1WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProZaghdadV1WebHostModule).GetAssembly());
        }
    }
}
