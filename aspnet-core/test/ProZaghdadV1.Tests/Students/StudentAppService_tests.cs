using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using ProZaghdadV1.Students;
using ProZaghdadV1.Students.Dto;
using ProZaghdadV1.Models;

namespace ProZaghdadV1.Tests.Students
{
    public class StudentAppService_Tests : ProZaghdadV1TestBase
    {
        private readonly IStudentAppService _studentAppService;

        public StudentAppService_Tests()
        {
            _studentAppService = Resolve<IStudentAppService>();
        }

        [Fact]
        public async Task GetStudents_Test()
        {
            // Act
            var output = await _studentAppService.GetAllAsync(new PagedStudentResultRequestDto{MaxResultCount=20, SkipCount=0} );

            // Assert
            output.Items.Count.ShouldBe(0);
        }

        [Fact]
        public async Task CreateStudent_Test()
        {
            // Act
            await UsingDbContextAsync(async context =>
            {
                await context.Colleges.AddAsync(new College { Id=0, Name = "Centennial" });
                context.SaveChanges();
            });

            await _studentAppService.CreateAsync(
                new CreateStudentDto
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Address = "10 Lee Centre Dr.",
                    ProgramName = "(555)165-6654",
                    DoB = "1999-01-01",
                    CollegeId = 0,
                    IsActive = true,
                });

            await UsingDbContextAsync(async context =>
            {
                var johnSmithStudent = await context.Students.FirstOrDefaultAsync(u => u.FirstName == "John");
                johnSmithStudent.ShouldNotBeNull();
            });
        }
    }
}
