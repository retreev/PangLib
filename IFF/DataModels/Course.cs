using System.Runtime.InteropServices;

namespace IFF.DataModels {

  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Course {
    public uint Active;  
    public uint ID;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 41)]
    public string Name;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 95)]
    public string Model;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string ShortName;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Unknown1;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 44)]
    public string PropertyFileName;
    public uint Unknown2;
  }
}