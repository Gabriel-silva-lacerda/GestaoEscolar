namespace GestaoEscolar.application.Responses;

public abstract class BaseResponse
{
    public bool Success { get; protected set; }

    protected BaseResponse(bool success)
    {
        Success = success;
    }
}
