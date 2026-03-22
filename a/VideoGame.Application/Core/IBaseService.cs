using VideoGame.Application.Dtos;

namespace VideoGame.Application.Core
{
    public interface IBaseService<TDto, TSaveDto>
        where TDto : DtoBase
        where TSaveDto : class
    {
        Task<ServiceResult<List<TDto>>> GetAllAsync();
        Task<ServiceResult<TDto>> GetByIdAsync(int id);
        Task<ServiceResult> SaveAsync(TSaveDto dto);
        Task<ServiceResult> UpdateAsync(int id, TSaveDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
