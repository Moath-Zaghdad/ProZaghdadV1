using Abp.Application.Services.Dto;

namespace ProZaghdadV1.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

