using System.Runtime.InteropServices;
using PangLib.IFF.Model.US.Season8.General;

namespace PangLib.IFF.Model.US.Season8.Data;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct Item
{
    [field: MarshalAs(UnmanagedType.Struct)]
    public IffCommon Header { get; set; }
    
    public uint ItemType { get; set; }
    
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Texture { get; set; }
    
    /// <summary>
    /// Array length 5.
    /// It represents the {Power, Control, Accuracy, Spin, Curve} this item gives.
    /// When the item is time-limited it says the price of the different days in the order of {1, 7, 15, 30, 365}
    /// </summary>
    public ushort PowerOrTimePrice1 { get; set; }
    public ushort ControlOrTimePrice7 { get; set; }
    public ushort AccuracyOrTimePrice15 { get; set; }
    public ushort SpinOrTimePrice30 { get; set; }
    public ushort CurveOrTimePrice365 { get; set; }
    
    /// <summary>
    /// Price when the item is not time-limited
    /// </summary>
    public ushort NoTimePrice { get; set; }
}