using System;

namespace PangLib.IFF.Model.Flag;

/// <summary>
/// This flag is handling shop display related values
/// </summary>
[Flags]
public enum ShopDisplayFlag : byte
{
    /// <summary>
    /// No special shop display condition
    /// </summary>
    None = 0,
    
    /// <summary>
    /// This shop item is active
    /// </summary>
    Active = 1 << 0,
    
    /// <summary>
    /// TODO: Figure out what this value is again
    /// </summary>
    Type = 1 << 1,
    
    /// <summary>
    /// Item is for display only
    /// </summary>
    OnlyForDisplay = 1 << 2,
    Unknown1 = 1 << 3,
    
    /// <summary>
    /// Displays a "New" banner on a shop item
    /// </summary>
    BannerNew = 1 << 4,
    
    /// <summary>
    /// Displays a "Hot" banner on a shop item
    /// </summary>
    BannerHot = 1 << 5,
    
    /// <summary>
    /// Displays a "Special" banner on a shop item
    /// </summary>
    BannerSpecial = 1 << 6,
    Unknown2 = 1 << 7
}