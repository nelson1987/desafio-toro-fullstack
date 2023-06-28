﻿using FluentValidation.Results;
using MediatR;
using ToroChallenge.Application.FilterAttributes;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoCommand : IRequest<InvestimentoResponse[]>, IValidable
    {
        public string LoginUsuario { get; set; }

        public ValidationResult GetValidation() => new InvestimentoCommandValidator().Validate(this);

        public bool HasError(out IList<ValidationFailure> errors)
        {
            errors = GetValidation().Errors;
            return !GetValidation().IsValid;
        }
    }
}
