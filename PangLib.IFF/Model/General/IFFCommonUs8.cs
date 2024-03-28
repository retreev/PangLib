using System.Runtime.InteropServices;
using PangLib.IFF.Model.Flag;
using PangLib.IFF.Model.Type;

namespace PangLib.IFF.Model.General;

/// <summary>
/// Common data structure found at the head of many IFF datasets
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct IFFCommonUs8
{
    /// <summary>
    /// Status of this object
    /// </summary>
    public uint Active { get; set; }
        
    /// <summary>
    /// ID of this object
    /// </summary>
    public uint ID { get; set; }
        
    /// <summary>
    /// Name of this object
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Name { get; set; }
        
    /// <summary>
    /// Level requirement for this object
    /// </summary>
    public byte Level { get; set; }
        
    /// <summary>
    /// Icon for this object
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
    public string Icon { get; set; }
        
    /// <summary>
    /// Price of this object
    /// </summary>
    public uint Price { get; set; }
        
    /// <summary>
    /// Discounted price of this object
    /// </summary>
    public uint DiscountPrice { get; set; }
        
    /// <summary>
    /// Used price of this object
    /// </summary>
    public uint UsedPrice { get; set; }
        
    /// <summary>
    /// Instance of <see cref="Flag.ShopFlag"/>
    /// </summary>
    public ShopFlag ShopFlag { get; set; }
        
    /// <summary>
    /// Instance of <see cref="ShopDisplayFlag"/>
    /// </summary>
    public ShopDisplayFlag MoneyFlag { get; set; }
        
    /// <summary>
    /// A time flag
    /// </summary>
    public ShopTimeFlag TimeFlag { get; set; }
    
    public ShopTempItemDurationType TempItemDuration { get; set; }
    
    /// <summary>
    /// The amount of items that gives the Tiki Shop for this "Tiki Buy"
    /// </summary>
    public uint TikiItemAmount { get; set; }
    
    /// <summary>
    /// Total Tiki Points to buy this "Tiki Buy"
    /// </summary>
    public uint TikiPointsPrice { get; set; }
    public ushort MileagePoints { get; set; }
    public ushort BonusProbability { get; set; }
    public ushort MinBonus { get; set; }
    public ushort MaxBonus { get; set; }
    
    /// <summary>
    /// TODO: Investigate
    /// </summary>
    public uint TikiShopType { get; set; }
    public uint TikiPang { get; set; }
    
    /// <summary>
    /// The object has time-limited availability
    /// </summary>
    public TimeLimitedType IsTimeLimited { get; set; }
        
    /// <summary>
    /// Time this object becomes available
    /// </summary>
    [field: MarshalAs(UnmanagedType.Struct)]
    public SystemTime StartTime { get; set; }
        
    /// <summary>
    /// Time this object stops being available
    /// </summary>
    [field: MarshalAs(UnmanagedType.Struct)]
    public SystemTime EndTime { get; set; }
}