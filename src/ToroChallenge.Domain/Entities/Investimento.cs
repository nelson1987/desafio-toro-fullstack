namespace ToroChallenge.Domain.Entities
{
    public class Investimento
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
