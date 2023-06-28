using FluentValidation;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoCommandValidator : AbstractValidator<InvestimentoCommand>
    {
        public InvestimentoCommandValidator()
        {
            RuleFor(x => x.LoginUsuario).NotEmpty().WithMessage("Necessário Login de Usuário");
        }
    }
}
