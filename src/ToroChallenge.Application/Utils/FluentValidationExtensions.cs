using FluentValidation.Results;

namespace ToroChallenge.Application.Utils
{
    public static class FluentValidationExtensions
    {
        public static IDictionary<string, string[]> ToDictionary(this ValidationResult validationResult)
        {
            return validationResult.Errors
              .GroupBy(x => x.PropertyName)
              .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
              );
            /*
             
		var errors = new List<SimpleError>();

		foreach (var pair in ModelState) {
			foreach (var error in pair.Value.Errors) {
				errors.Add(new SimpleError {Name = pair.Key, Message = error.ErrorMessage});
			}
		}

		return Json(errors);
	}
             */
        }
    }
}
