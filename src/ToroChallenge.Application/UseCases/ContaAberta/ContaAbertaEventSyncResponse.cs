namespace ToroChallenge.Application.UseCases.ContaAberta
{
    public class ContaAbertaEventSyncResponse
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int IdCliente { get; set; }
        public string Agencia { get; set; }
    }
}