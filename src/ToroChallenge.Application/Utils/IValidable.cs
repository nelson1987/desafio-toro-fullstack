namespace ToroChallenge.Application.Utils
{
    public interface IValidable
    {
        bool HasError(out IDictionary<string, string[]> errors);
    }
}
