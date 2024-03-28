using System;

namespace PangLib.IFF.Model.US.Season8.Flag;

/// <summary>
/// This flag is handling buying conditions
/// </summary>
[Flags]
public enum ShopFlag : byte
{
    /// <summary>
    /// No special buying conditions
    /// </summary>
    None = 0,
    
    /// <summary>
    /// This shop item can be gifted
    /// </summary>
    CanBeGifted = 1 << 0,
    
    /// <summary>
    /// This shop item cannot be gifted
    /// </summary>
    CannotBeGifted = 1 << 1,
    
    /// <summary>
    /// This shop item is a coupon
    /// </summary>
    Coupon = 1 << 2,
    
    Unknown1 = 1 << 3,
    Unknown2 = 1 << 4,
    Unknown3 = 1 << 5,
    Unknown4 = 1 << 6,
    Unknown5 = 1 << 7
}