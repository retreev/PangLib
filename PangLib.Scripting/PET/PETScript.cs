using System.Collections.Generic;
using PETToken = PangLib.Scripting.Token<PangLib.Scripting.PET.PETTokenType>;
using PETTokenDefinition = PangLib.Scripting.TokenDefinition<PangLib.Scripting.PET.PETTokenType>;

namespace PangLib.Scripting.PET
{
    public class PETScript
    {
        public List<PETToken> Tokens;

        public PETScript(string petScript)
        {
            Tokenizer<PETTokenType> tokenizer = new Tokenizer<PETTokenType>(
                new List<PETTokenDefinition>
                {
                    new PETTokenDefinition(PETTokenType.Asterisk, @"^\*"),
                    new PETTokenDefinition(PETTokenType.CommandName, @"^\w+"),
                    new PETTokenDefinition(PETTokenType.OpenParenthesis, "^\\("),
                    new PETTokenDefinition(PETTokenType.Argument, "^\"[^\"]*\"{1}"),
                    new PETTokenDefinition(PETTokenType.CloseParenthesis, "^\\)")
                }
            );

            Tokens = tokenizer.Tokenize(petScript);
        }
    }
}