using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.Students.Dto
{
    [AutoMapTo(typeof(Student))]
    public class UpdateStudentDto : EntityDto<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ProgramName { get; set; }
        public string DoB { get; set; }
        public bool IsActive { get; set; }
///UpdateDto.cs.fields1///

    }
}
