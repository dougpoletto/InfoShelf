namespace InfoShelf.Server.Domain.Models.DTO
{
    public class BaseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class BaseDto<T> : BaseDto
    {
        public T? Response { get; set; }
    }
}
