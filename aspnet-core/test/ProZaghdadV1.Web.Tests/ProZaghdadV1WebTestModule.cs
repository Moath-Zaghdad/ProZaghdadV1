using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProZaghdadV1.EntityFrameworkCore;
using ProZaghdadV1.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ProZaghdadV1.Web.Tests
{
    [DependsOn(
        typeof(ProZaghdadV1WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ProZaghdadV1WebTestModule : AbpModule
    {
        public ProZaghdadV1WebTestModule(ProZaghdadV1EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProZaghdadV1WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ProZaghdadV1WebMvcModule).Assembly);
        }
    }
}