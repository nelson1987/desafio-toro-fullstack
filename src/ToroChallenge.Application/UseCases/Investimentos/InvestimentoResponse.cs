using ToroChallenge.Domain.Entities;

namespace ToroChallenge.Application.UseCases.Investimentos
{
    public class InvestimentoResponse
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public decimal GetSaldo()
        {
            return Valor * Quantidade;
        }
        public static InvestimentoResponse FromModel(Investimento investimento)
        {
            return new InvestimentoResponse() { Valor = investimento.Valor, DataAtualizacao = investimento.DataAtualizacao };
        }
    }
}
