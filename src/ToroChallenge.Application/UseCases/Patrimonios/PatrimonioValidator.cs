﻿using FluentValidation;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioValidator : AbstractValidator<PatrimonioCommand>
    {
        public PatrimonioValidator()
        {
            RuleFor(x => x.LoginUsuario).NotEmpty().WithMessage("Necessário Login de Usuário");
        }
    }
}
