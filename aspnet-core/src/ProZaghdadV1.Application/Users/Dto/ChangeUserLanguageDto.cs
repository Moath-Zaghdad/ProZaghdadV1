using System.ComponentModel.DataAnnotations;

namespace ProZaghdadV1.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}