namespace GestaoEscolar.application.Responses;

public class ErrorResponse : BaseResponse
{
    public IEnumerable<string> Errors { get; set; }

    public ErrorResponse(IEnumerable<string> errors) : base(false)
    {
        Errors = errors ?? new List<string> { "Ocorreu um erro inesperado." };
    }
}
