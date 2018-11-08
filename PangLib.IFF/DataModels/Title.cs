using System.Runtime.InteropServices;

namespace PangLib.IFF.DataModels
{
  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Title {
    public uint Active;
    public uint ID;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Name;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Icon;
  }
}