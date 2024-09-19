using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ProZaghdadV1.Configuration;
using ProZaghdadV1.EntityFrameworkCore;
using ProZaghdadV1.Migrator.DependencyInjection;

namespace ProZaghdadV1.Migrator
{
    [DependsOn(typeof(ProZaghdadV1EntityFrameworkModule))]
    public class ProZaghdadV1MigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ProZaghdadV1MigratorModule(ProZaghdadV1EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ProZaghdadV1MigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ProZaghdadV1Consts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ProZaghdadV1MigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
