using Microsoft.AspNetCore.Mvc.Filters;

namespace ToroChallenge.Application.Utils
{
    public class ValidationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IValidable validable = context.ActionArguments["request"] as IValidable;
            if (validable.HasError(out IDictionary<string, string[]> errors))
            {
                ErroValidacao(context, errors);
            }
        }
        private void ErroValidacao(ActionExecutingContext context, IDictionary<string, string[]> erros)
        {
            var errors = new List<SimpleError>();

            foreach (var pair in erros)
            {
                //foreach (var error in pair.Value)
                //{
                //    errors.Add(new SimpleError { Name = pair.Key, Message = error.ErrorMessage });
                //}
            }

            //return Json(errors);
            var response = new
            {
                //erros = erros.Select((ValidationFailure c) => new Error(c.ErrorCode, c.PropertyName, c.ErrorMessage))
            };
            SetResponse(context, StatusCode(412, response));
        }

        private ObjectResult StatusCode(int status, object response = null)
        {
            return new ObjectResult();
            //return new ObjectResult(response)
            //{
            //    StatusCode = status
            //};
        }

        private void SetResponse(ActionExecutingContext context, ObjectResult result)
        {
            //context.Result = result;
        }
    }
}
