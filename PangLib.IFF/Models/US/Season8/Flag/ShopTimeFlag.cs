using System;

namespace PangLib.IFF.Models.US.Season8.Flag;

[Flags]
public enum ShopTimeFlag : byte
{
    None = 0,
    Active = 1 << 0
}