

namespace Core.Utilities.Results
{
    //temel voidler için
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
