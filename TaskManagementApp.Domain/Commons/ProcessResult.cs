namespace TaskManagementApp.Domain.Commons;

public interface IProcessResult
{
    bool IsSuccess { get; set; }
    string Message { get; set; }
}

public interface IProcessResult<T> : IProcessResult
{
    T Data { get; set; }
}

public class ProcessResult : IProcessResult
{
    public ProcessResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class ProcessResult<T> : ProcessResult, IProcessResult<T>
{
    public ProcessResult(bool isSuccss, string message, T data) : base(isSuccss, message)
    {
        Data = data;
    }

    public T Data { get; set; }
}

public class PagedResult<T>
{
    public PagedResult(T records, int total)
    {
        Records = records;
        Total = total;
    }
    public T? Records { get; set; }
    public int Total { get; set; }
}