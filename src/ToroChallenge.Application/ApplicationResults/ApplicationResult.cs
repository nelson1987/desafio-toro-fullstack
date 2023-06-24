using ToroChallenge.Application.Resources;

namespace ToroChallenge.Application.ApplicationResults
{
    public class ObjectResult
    {
        public ObjectResult(bool status, string message)
        {
            Message = message;
            Status = status;
        }

        public string Message { get; set; }
        public bool Status { get; set; }
    }
    public interface IApplicationResult
    {
        string Message { get; }
        bool Status { get; }
        void Sucess();
        void NotFound(string message);
        ObjectResult NotFound(ErroMessages message);
        void UnAuthorized();
        void Failed(string message);
        ObjectResult Failed(ErroMessages message);
    }
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
