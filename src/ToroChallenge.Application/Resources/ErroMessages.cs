namespace ToroChallenge.Application.Resources
{
    public class ErroMessages
    {
        public int CodigoErro { get; private set; }
        public string Message { get; private set; }
        public ErroMessages(int codigo, string message)
        {
            CodigoErro = codigo;
            Message = message;
        }
    }
}
