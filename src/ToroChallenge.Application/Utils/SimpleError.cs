namespace ToroChallenge.Application.Utils
{
    public class SimpleError
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"Property: {Name} Message: {Message}";
        }
    }
}
