using FluentValidation.Results;
using ToroChallenge.Application.Resources;

namespace ToroChallenge.Application.ApplicationResults
{
    public interface IApplicationResult
    {
        string Message { get; }
        bool Success { get; }
        void Sucess();
        void NotFound(string message);
        ObjectResult NotFound(ErroMessages message);
        void UnAuthorized();
        void Failed(string message);
        ObjectResult Failed(ErroMessages message);
        ObjectResult Failed(IList<ValidationFailure> message);
    }
}
