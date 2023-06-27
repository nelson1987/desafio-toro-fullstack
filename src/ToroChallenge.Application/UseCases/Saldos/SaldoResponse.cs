using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.UseCases.Saldos
{
    public class SaldoResponse
    {
        public decimal Valor { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public static SaldoResponse FromModel(Balance saldo)
        {
            return new SaldoResponse() { Valor = saldo.Valor, DataAtualizacao = saldo.DataAtualizacao };
        }
    }
}
