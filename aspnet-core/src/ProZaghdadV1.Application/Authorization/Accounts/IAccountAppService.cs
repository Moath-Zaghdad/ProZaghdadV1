using System.Threading.Tasks;
using Abp.Application.Services;
using ProZaghdadV1.Authorization.Accounts.Dto;

namespace ProZaghdadV1.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
