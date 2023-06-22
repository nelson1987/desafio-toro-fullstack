using FluentValidation;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoValidator : AbstractValidator<InvestimentoCommand>
    {
        public InvestimentoValidator()
        {
            RuleFor(x => x.LoginUsuario).NotEmpty().WithMessage("Necessário Login de Usuário");
        }
    }
}
