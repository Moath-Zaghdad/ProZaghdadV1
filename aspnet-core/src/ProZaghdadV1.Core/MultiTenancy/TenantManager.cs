using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using ProZaghdadV1.Authorization.Users;
using ProZaghdadV1.Editions;

namespace ProZaghdadV1.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
