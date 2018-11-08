using System.Runtime.InteropServices;

namespace PangLib.IFF.DataModels
{
  [StructLayout (LayoutKind.Sequential, Pack = 4)]
  public struct Enchant {
    public uint Active;
    public uint ID;
    public uint Price;
  }
}