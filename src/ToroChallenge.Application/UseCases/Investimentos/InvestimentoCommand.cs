using FluentValidation.Results;
using MediatR;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoCommand : IRequest<InvestimentoResponse[]>, IValidable
    {
        public string LoginUsuario { get; set; }

        public ValidationResult GetValidation() => new InvestimentoCommandValidator().Validate(this);

        public bool HasError(out IDictionary<string, string[]> errors)
        {
            errors = GetValidation().ToDictionary();
            return !GetValidation().IsValid;
        }
    }
}
