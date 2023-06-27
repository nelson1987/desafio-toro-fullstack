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
}
