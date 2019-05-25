namespace PangLib.IFF.Models.Flags
{
    /// <summary>
    /// This flag is handling shop display related values
    /// </summary>
    public enum MoneyFlag : byte
    {
        /// <summary>
        /// Unknown value
        /// </summary>
        Unknown1 = 128,
        
        /// <summary>
        /// Displays a "Special" banner on a shop item
        /// </summary>
        BannerSpecial = 64,
        
        /// <summary>
        /// Displays a "Hot" banner on a shop item
        /// </summary>
        BannerHot = 32,
        
        /// <summary>
        /// Displays a "New" banner on a shop item
        /// </summary>
        BannerNew = 16,
        
        /// <summary>
        /// Unknown value
        /// </summary>
        Unknown2 = 8,
        
        /// <summary>
        /// Item is for display only
        /// </summary>
        DisplayOnly = 4,
        
        /// <summary>
        /// TODO: Figure out what this value is again
        /// </summary>
        Type = 2,
        
        /// <summary>
        /// This shop item is active
        /// </summary>
        Active = 1,
        
        /// <summary>
        /// No special shop display condition
        /// </summary>
        None = 0
    }
}
