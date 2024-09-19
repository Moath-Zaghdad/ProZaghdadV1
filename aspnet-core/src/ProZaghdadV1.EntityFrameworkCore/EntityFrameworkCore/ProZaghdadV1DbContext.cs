using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ProZaghdadV1.Authorization.Roles;
using ProZaghdadV1.Authorization.Users;
using ProZaghdadV1.MultiTenancy;

namespace ProZaghdadV1.EntityFrameworkCore
{
    public class ProZaghdadV1DbContext : AbpZeroDbContext<Tenant, Role, User, ProZaghdadV1DbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ProZaghdadV1DbContext(DbContextOptions<ProZaghdadV1DbContext> options)
            : base(options)
        {
        }
    }
}
