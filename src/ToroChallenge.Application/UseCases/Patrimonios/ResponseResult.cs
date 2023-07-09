using Microsoft.AspNetCore.Mvc;

namespace ToroChallenge.Application.UseCases.Patrimonios
{
    public class ResponseResult<T> : ActionResult
    {
        public string title { get; set; }
        public int status { get; set; }
        public IDictionary<string, string[]> errors { get; set; }

        public ResponseResult(int status, IDictionary<string, string[]> dictionary)
        {
            this.title = "One or more validation errros occured";
            this.status = status;
            this.errors = dictionary;
        }
    }
}
