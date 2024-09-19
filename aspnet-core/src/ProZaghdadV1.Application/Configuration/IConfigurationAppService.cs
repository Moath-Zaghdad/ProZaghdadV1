using System.Threading.Tasks;
using ProZaghdadV1.Configuration.Dto;

namespace ProZaghdadV1.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
