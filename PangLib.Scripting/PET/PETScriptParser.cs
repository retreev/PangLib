using System.Collections.Generic;
using PETToken = PangLib.Scripting.Token<PangLib.Scripting.PET.PETTokenType>;

namespace PangLib.Scripting.PET
{
    /// <summary>
    /// PET script parsed implementation used in <see cref="PETScript"/>
    /// </summary>
    public class PETScriptParser
    {
        /// <summary>
        /// Stack containing all <see cref="PETTokenType"/>s to be parsed
        /// </summary>
        private readonly Stack<PETToken> TokenSequence;

        /// <summary>
        /// Constructor for the <see cref="PETScriptParser"/>
        /// </summary>
        /// <param name="Tokens">List of tokens to be parsed</param>
        public PETScriptParser(List<PETToken> Tokens)
        {
            Tokens.Reverse();
            TokenSequence = new Stack<PETToken>(Tokens);
        }
        
        /// <summary>
        /// Steps through <see cref="TokenSequence"/> and parses the tokens into objects
        /// </summary>
        /// <returns><see cref="PETCommand"/>s parsed from <see cref="PETTokenType"/>s</returns>
        public List<PETCommand> Parse()
        {
            List<PETCommand> commands = new List<PETCommand>();

            while (TokenSequence.Count > 0)
            {
                commands.Add(ReadCommand());
            }

            return commands;
        }

        /// <summary>
        /// Parsing function that returns <see cref="PETCommand"/>s contained in the PET script
        /// </summary>
        /// <returns>A single instance of <see cref="PETCommand"/> parsed from the <see cref="TokenSequence"/></returns>
        private PETCommand ReadCommand()
        {
            PETCommand command = new PETCommand();

            command.Name = TokenSequence.Pop().Value.TrimStart('*');
            command.Arguments = new List<string>();
            
            if (TokenSequence.Peek().TokenType == PETTokenType.OpenParenthesis)
            {
                TokenSequence.Pop();
                
                while (TokenSequence.Peek().TokenType != PETTokenType.CloseParenthesis)
                {
                    command.Arguments.Add(TokenSequence.Pop().Value.Trim('"'));
                }
                
                TokenSequence.Pop();
            }

            return command;
        }
    }
}