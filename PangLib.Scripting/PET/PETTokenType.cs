namespace PangLib.Scripting.PET;

/// <summary>
/// All token types used in <see cref="PETScript"/>
/// </summary>
public enum PETTokenType
{
    /// <summary>
    /// An argument in a <see cref="PETCommand"/>
    ///
    /// <example>"__facetexture__"</example>
    /// </summary>
    Argument,
        
    /// <summary>
    /// A closing parenthesis
    ///
    /// <example>)</example>
    /// </summary>
    CloseParenthesis,
        
    /// <summary>
    /// Name of a <see cref="PETCommand"/>
    ///
    /// <example>*ptex</example>
    /// </summary>
    CommandName,
        
    /// <summary>
    /// A opening parenthesis
    ///
    /// <example>(</example>
    /// </summary>
    OpenParenthesis
}