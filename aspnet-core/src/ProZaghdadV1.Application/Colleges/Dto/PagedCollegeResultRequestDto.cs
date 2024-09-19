using Abp.Application.Services.Dto;

namespace ProZaghdadV1.Colleges.Dto
{
    public class PagedCollegeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
