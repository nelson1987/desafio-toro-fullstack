using FluentValidation;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public class SaldoValidator : AbstractValidator<SaldoCommand>
    {
        public SaldoValidator()
        {
            RuleFor(x => x.LoginUsuario).NotEmpty().WithMessage("Necessário Login de Usuário");
        }
    }
}
