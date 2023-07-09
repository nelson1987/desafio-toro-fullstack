namespace ToroChallenge.Application.Utils
{
    public class Error
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public Error()
        {

        }

        public Error(string code, string title, string detail)
        {
            Code = code;
            Title = title;
            Detail = detail;
        }
    }
}
