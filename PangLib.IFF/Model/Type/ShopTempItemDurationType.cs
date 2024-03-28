namespace PangLib.IFF.Model.Type;

public enum ShopTempItemDurationType : byte
{
    None = 0,
    Day = 1,
    Week = 7,
    TwoWeeks = 15,
    Month = 30,
    Year = 0x6D
}