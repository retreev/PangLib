namespace PangLib.Scripting;

public class Token<T> where T : new()
{
    public T TokenType { get; set; }
    public string Value { get; set; }
        
    public Token(T tokenType)
    {
        TokenType = tokenType;
        Value = string.Empty;
    }

    public Token(T tokenType, string value)
    {
        TokenType = tokenType;
        Value = value;
    }
}