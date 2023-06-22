using System.Text.Json;

namespace ToroChallenge.Application.Utils
{
    public static class Extensions
    {
        public static string ToJson(this object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
