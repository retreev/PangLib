using System.Collections.Generic;
using PETToken = PangLib.Scripting.Token<PangLib.Scripting.PET.PETTokenType>;
using PETTokenDefinition = PangLib.Scripting.TokenDefinition<PangLib.Scripting.PET.PETTokenType>;

namespace PangLib.Scripting.PET
{
    /// <summary>
    /// Class containing tokenizing and parsing utilities for a custom script format included
    /// in Puppet (.?pet) files
    /// </summary>
    public class PETScript
    {
        /// <summary>
        /// Parsed commands from the tokens of the PET script
        /// </summary>
        public List<PETCommand> Commands { get; }

        /// <summary>
        /// Constructor for <see cref="PETScript"/>, tokenizing and parsing the PET script
        /// </summary>
        /// <param name="petScript">The PET script to be parsed</param>
        public PETScript(string petScript)
        {
            Tokenizer<PETTokenType> tokenizer = new Tokenizer<PETTokenType>(
                new List<PETTokenDefinition>
                {
                    new PETTokenDefinition(PETTokenType.CommandName, @"^\*\w+"),
                    new PETTokenDefinition(PETTokenType.OpenParenthesis, "^\\("),
                    new PETTokenDefinition(PETTokenType.Argument, "^\"[^\"]*\"{1}"),
                    new PETTokenDefinition(PETTokenType.CloseParenthesis, "^\\)")
                }
            );

            List<PETToken> tokens = tokenizer.Tokenize(petScript);
            
            Commands = new PETScriptParser(tokens).Parse();
        }
    }
}