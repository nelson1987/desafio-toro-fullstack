using Microsoft.AspNetCore.Mvc;
using ToroChallenge.Application.UseCases.Patrimonios;

namespace ToroChallenge.Application.ApplicationServices
{
    public interface IInvestimentoApplicationService
    {
        Task<PatrimonioResponse> PostSaldoAsync([FromBody] PatrimonioCommand request, CancellationToken cancellationToken);
        Task<PatrimonioResponse> PostFilaAsync([FromBody] PatrimonioCommand request, CancellationToken cancellationToken);
    }
}
