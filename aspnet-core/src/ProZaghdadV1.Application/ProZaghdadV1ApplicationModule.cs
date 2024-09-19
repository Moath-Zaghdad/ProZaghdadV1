using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProZaghdadV1.Authorization;

namespace ProZaghdadV1
{
    [DependsOn(
        typeof(ProZaghdadV1CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ProZaghdadV1ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ProZaghdadV1AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ProZaghdadV1ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
