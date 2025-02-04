namespace GestaoEscolar.application.Responses;

public class SuccessResponse<T> : BaseResponse
{
    public T Data { get; set; }
    public string Message { get; set; }

    public SuccessResponse(T data, string message = null) : base(true)
    {
        Data = data;
        Message = message;
    }
}
