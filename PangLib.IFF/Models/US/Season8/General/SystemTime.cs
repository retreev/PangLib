using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.US.Season8.General;

/// <summary>
/// System time structure based on Windows internal SYSTEMTIME struct
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct SystemTime
{
    /// <summary>
    /// Year
    /// </summary>
    public ushort Year { get; set; }
        
    /// <summary>
    /// Month
    /// </summary>
    public ushort Month { get; set; }
        
    /// <summary>
    /// Day of Week
    /// </summary>
    public ushort DayOfWeek { get; set; }
        
    /// <summary>
    /// Day
    /// </summary>
    public ushort Day { get; set; }
        
    /// <summary>
    /// Hour
    /// </summary>
    public ushort Hour { get; set; }
        
    /// <summary>
    /// Minute
    /// </summary>
    public ushort Minute { get; set; }
        
    /// <summary>
    /// Second
    /// </summary>
    public ushort Second { get; set; }
        
    /// <summary>
    /// Millisecond
    /// </summary>
    public ushort MilliSecond { get; set; }
}