using ToroChallenge.Application.Resources;

namespace ToroChallenge.Application.ApplicationResults
{
    public class ApplicationResult : IApplicationResult
    {
        public string Message { get; set; }
        public bool Status { get; set; }

        public void Sucess() { }
        public void UnAuthorized() { }

        public void NotFound(string message)
        {
            Status = false;
            Message = message;
        }
        public ObjectResult NotFound(ErroMessages message)
        {
            Status = false;
            Message = message.Message;
            return new ObjectResult(this.Status, this.Message);
        }

        public void Failed(string message)
        {
            Status = false;
            Message = message;
        }
        public ObjectResult Failed(ErroMessages message)
        {
            Status = false;
            Message = message.Message;
            return new ObjectResult(this.Status, this.Message);
        }
    }
}
