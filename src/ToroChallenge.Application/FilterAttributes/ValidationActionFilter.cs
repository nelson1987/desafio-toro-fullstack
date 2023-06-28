using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToroChallenge.Application.FilterAttributes
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IValidable validable = context.ActionArguments["request"] as IValidable;
            if (validable.HasError(out IList<ValidationFailure> errors))
            {
                ErroValidacao(context, errors);
            }
            //base.OnActionExecuting(context);
        }
        private void ErroValidacao(ActionExecutingContext context, IList<ValidationFailure> erros)
        {
            var response = new
            {
                erros = erros.Select((ValidationFailure c) => new Error(c.ErrorCode, c.PropertyName, c.ErrorMessage))
            };
            SetResponse(context, StatusCode(412, response));
        }

        private ObjectResult StatusCode(int status, object response = null)
        {
            return new ObjectResult(response)
            {
                StatusCode = status
            };
        }

        private void SetResponse(ActionExecutingContext context, ObjectResult result)
        {
            context.Result = result;
        }
    }

    public interface IValidable
    {
        bool HasError(out IList<ValidationFailure> errors);
    }

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
