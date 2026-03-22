using VideoGame.Application.Core;
using VideoGame.Application.Dtos.Game;

namespace VideoGame.Application.Contract
{
    public interface IGameService : IBaseService<GameDto, SaveGameDto>
    {
    }
}
