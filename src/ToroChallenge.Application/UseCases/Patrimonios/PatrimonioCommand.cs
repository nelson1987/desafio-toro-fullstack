using FluentValidation.Results;
using MediatR;
using ToroChallenge.Application.Utils;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioCommand : IRequest<ResponseResult<PatrimonioResponse>>, IValidable
    {
        public string LoginUsuario { get; set; }

        public ValidationResult GetValidation() => new PatrimonioValidator().Validate(this);

        public bool HasError(out IDictionary<string, string[]> errors)
        {
            errors = GetValidation().ToDictionary();
            return !GetValidation().IsValid;
        }

        public static explicit operator PatrimonioResponse(PatrimonioCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
