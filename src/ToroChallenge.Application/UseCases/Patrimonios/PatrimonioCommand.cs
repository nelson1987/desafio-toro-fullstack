using FluentValidation.Results;
using MediatR;
using ToroChallenge.Application.FilterAttributes;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioCommand : IRequest<PatrimonioResponse>, IValidable
    {
        public string LoginUsuario { get; set; }

        public ValidationResult GetValidation() => new PatrimonioValidator().Validate(this);

        public bool HasError(out IList<ValidationFailure> errors)
        {
            errors = GetValidation().Errors;
            return !GetValidation().IsValid;
        }
    }
}
