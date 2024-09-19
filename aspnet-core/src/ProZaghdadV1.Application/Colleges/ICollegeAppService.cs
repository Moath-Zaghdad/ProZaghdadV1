using Abp.Application.Services;
using ProZaghdadV1.Colleges.Dto;

namespace ProZaghdadV1.Colleges
{
    public interface ICollegeAppService : IAsyncCrudAppService<CollegeDto, int, PagedCollegeResultRequestDto, CreateCollegeDto, UpdateCollegeDto>
    {

    }
}
