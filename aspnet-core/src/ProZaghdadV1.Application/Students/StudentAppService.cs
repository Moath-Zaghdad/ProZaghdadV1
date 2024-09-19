using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ProZaghdadV1.Authorization;
using ProZaghdadV1.Students.Dto;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.Students
{

    // [AbpAuthorize(PermissionNames.Pages_Students)]
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>, IStudentAppService
    {
        public StudentAppService
        (
            IRepository<Student, int> repository
        )
        : base(repository)
        {

        }

    }
}
