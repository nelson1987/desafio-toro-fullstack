namespace ToroChallenge.Application.Utils
{
    public class ApplicationResult : IApplicationResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }

        public void Sucess() { }
        public void UnAuthorized() { }

        public void NotFound(string message)
        {
            Success = false;
            Message = message;
        }
        public ObjectResult NotFound(ErroMessages message)
        {
            Success = false;
            Message = message.Message;
            return new ObjectResult(Success, Message);
        }

        public void Failed(string message)
        {
            Success = false;
            Message = message;
        }
        public ObjectResult Failed(ErroMessages message)
        {
            Success = false;
            Message = message.Message;
            return new ObjectResult(Success, Message);
        }

        public ObjectResult Failed(IDictionary<string, string[]> message)
        {
            Success = false;
            Message = message.ToJson();
            return new ObjectResult(Success, Message);
        }
    }
}
