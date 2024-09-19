using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ProZaghdadV1.Authorization;
using ProZaghdadV1.Colleges.Dto;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.Colleges
{

    [AbpAuthorize(PermissionNames.Pages_Colleges)]
    public class CollegeAppService : AsyncCrudAppService<College, CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, UpdateCollegeDto>, ICollegeAppService
    {
        public CollegeAppService
        (
            IRepository<College, int> repository
        )
        : base(repository)
        {

        }

    }
}
