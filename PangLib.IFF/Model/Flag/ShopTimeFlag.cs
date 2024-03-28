using System;

namespace PangLib.IFF.Model.Flag;

[Flags]
public enum ShopTimeFlag : byte
{
    None = 0,
    Active = 1 << 0
}