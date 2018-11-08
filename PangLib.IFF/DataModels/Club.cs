using System.Runtime.InteropServices;
using PangLib.IFF.GeneralModels;

namespace PangLib.IFF.DataModels
{
  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Club {
    [MarshalAs (UnmanagedType.Struct)]
    public IFFCommon Header;
    [MarshalAs (UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Model;
  }
}