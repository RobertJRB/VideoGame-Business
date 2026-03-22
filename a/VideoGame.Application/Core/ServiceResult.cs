namespace VideoGame.Application.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public static ServiceResult Ok(string message = "Operación exitosa.")
            => new ServiceResult { Success = true, Message = message };

        public static ServiceResult Fail(string message)
            => new ServiceResult { Success = false, Message = message };
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }

        public static ServiceResult<T> Ok(T data, string message = "Operación exitosa.")
            => new ServiceResult<T> { Success = true, Message = message, Data = data };

        public static ServiceResult<T> Fail(string message)
            => new ServiceResult<T> { Success = false, Message = message };
    }
}
