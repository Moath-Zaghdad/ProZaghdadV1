using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ProZaghdadV1.Configuration;
using ProZaghdadV1.Web;

namespace ProZaghdadV1.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ProZaghdadV1DbContextFactory : IDesignTimeDbContextFactory<ProZaghdadV1DbContext>
    {
        public ProZaghdadV1DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ProZaghdadV1DbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ProZaghdadV1DbContextConfigurer.Configure(builder, configuration.GetConnectionString(ProZaghdadV1Consts.ConnectionStringName));

            return new ProZaghdadV1DbContext(builder.Options);
        }
    }
}
