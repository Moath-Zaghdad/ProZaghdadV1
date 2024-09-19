using Abp.Application.Services;
using ProZaghdadV1.MultiTenancy.Dto;

namespace ProZaghdadV1.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

