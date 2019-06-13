using System.Text.RegularExpressions;

namespace PangLib.Scripting
{
    public class TokenDefinition<T> where T : new()
    {
        private Regex Regex;
        private readonly T ReturnToken;
        
        public TokenDefinition(T returnToken, string regexPattern)
        {
            Regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            ReturnToken = returnToken;
        }
        
        public TokenMatch<T> Match(string inputString)
        {
            var match = Regex.Match(inputString);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != inputString.Length)
                    remainingText = inputString.Substring(match.Length);

                return new TokenMatch<T>
                {
                    IsMatch = true,
                    RemainingText = remainingText,
                    TokenType = ReturnToken,
                    Value = match.Value
                };
            }
            
            return new TokenMatch<T> { IsMatch = false};
        }
    }
}