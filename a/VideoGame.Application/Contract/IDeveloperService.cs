using VideoGame.Application.Core;
using VideoGame.Application.Dtos.Developer;

namespace VideoGame.Application.Contract
{
    public interface IDeveloperService : IBaseService<DeveloperDto, SaveDeveloperDto>
    {
    }
}
