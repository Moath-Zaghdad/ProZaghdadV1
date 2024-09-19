using System.Threading.Tasks;
using Abp.Application.Services;
using ProZaghdadV1.Sessions.Dto;

namespace ProZaghdadV1.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
