namespace PangLib.Scripting
{
    public class TokenMatch<T> where T : new()
    {
        public bool IsMatch { get; set; }
        public T TokenType { get; set; }
        public string Value { get; set; }
        public string RemainingText { get; set; }
    }
}