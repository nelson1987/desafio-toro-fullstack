namespace ToroChallenge.Application.Resources
{
    public static class DicionarioMessages
    {
        public static ErroMessages LoginUsuarioObrigatorio { get { return new ErroMessages(1, "Login de usuário está vazio."); } }
        public static ErroMessages SaldoNaoEncontrado { get { return new ErroMessages(2, "Saldo não encontrado."); } }
        public static ErroMessages NenhumInvestimentoFoiEncontrado { get { return new ErroMessages(3, "Nenhum Investimento foi encontrado."); } }
    }
}
