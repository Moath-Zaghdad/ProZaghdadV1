using Abp.Application.Services;
using ProZaghdadV1.Students.Dto;

namespace ProZaghdadV1.Students
{
    public interface IStudentAppService : IAsyncCrudAppService<StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>
    {

    }
}
