using System.Linq;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ProZaghdadV1.Authorization;
using ProZaghdadV1.Students.Dto;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.Students
{

    [AbpAuthorize(PermissionNames.Pages_Students)]
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, UpdateStudentDto>, IStudentAppService
    {
        public StudentAppService
        (
            IRepository<Student, int> repository
        )
        : base(repository)
        {

        }


        protected override IQueryable<Student> CreateFilteredQuery(PagedStudentResultRequestDto input)
        {
            IQueryable<Student> query = Repository.GetAll();
            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(input.Keyword) || x.LastName.Contains(input.Keyword) || x.ProgramName.Contains(input.Keyword));
            }
            if (input.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == input.IsActive);
            }

            return query;
        }
    }
}
