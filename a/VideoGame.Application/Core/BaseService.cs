using VideoGame.Application.Dtos;

namespace VideoGame.Application.Core
{
    public abstract class BaseService<TDto, TSaveDto>
        where TDto : DtoBase
        where TSaveDto : class
    {
        public abstract Task<ServiceResult<List<TDto>>> GetAllAsync();
        public abstract Task<ServiceResult<TDto>> GetByIdAsync(int id);
        public abstract Task<ServiceResult> SaveAsync(TSaveDto dto);
        public abstract Task<ServiceResult> UpdateAsync(int id, TSaveDto dto);
        public abstract Task<ServiceResult> DeleteAsync(int id);
    }
}
