using ToroChallenge.Application.UseCases.Investimentos;
using ToroChallenge.Application.UseCases.Saldos;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class PatrimonioResponse
    {
        public SaldoResponse Saldo { get; set; }
        public InvestimentoResponse[] Ativos { get; set; }
        public decimal Patrimonio
        {
            get
            {
                return Saldo.Valor + Ativos.Sum(x => x.GetSaldo());
            }
        }
    }
}
