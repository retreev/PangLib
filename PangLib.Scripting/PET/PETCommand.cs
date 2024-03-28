using System.Collections.Generic;

namespace PangLib.Scripting.PET;

/// <summary>
/// Basic structure for a command used in <see cref="PETScript"/>
/// </summary>
public struct PETCommand
{
    /// <summary>
    /// Name of the command
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// List of the arguments of the command
    /// </summary>
    public List<string> Arguments { get; set; }
}