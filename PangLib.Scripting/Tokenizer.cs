using System.Collections.Generic;

namespace PangLib.Scripting;

public class Tokenizer<T> where T : new()
{
    private List<TokenDefinition<T>> TokenDefinitions;
        
    public Tokenizer(List<TokenDefinition<T>> tokenDefinitions)
    {
        TokenDefinitions = tokenDefinitions;
    }

    public List<Token<T>> Tokenize(string inputString)
    {
        List<Token<T>> token = new List<Token<T>>();
        string remainingText = inputString;

        while (!string.IsNullOrWhiteSpace(remainingText))
        {
            TokenMatch<T> match = FindMatch(remainingText);

            if (match.IsMatch)
            {
                token.Add(new Token<T>(match.TokenType, match.Value));
                remainingText = match.RemainingText;
            }
            else
            {
                remainingText = remainingText.Substring(1);
            }
        }
            
        return token;
    }
        
    private TokenMatch<T> FindMatch(string inputString)
    {
        foreach (var tokenDefinition in TokenDefinitions)
        {
            var match = tokenDefinition.Match(inputString);
            if (match.IsMatch)
                return match;
        }

        return new TokenMatch<T> {  IsMatch = false };
    }
}