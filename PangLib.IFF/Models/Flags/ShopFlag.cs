namespace PangLib.IFF.Models.Flags
{
    public enum ShopFlag : byte
    {
        Unknown1 = 128,
        Unknown2 = 64,
        Unknown3 = 32,
        Unknown4 = 16,
        Unknown5 = 8,
        Coupon = 4,
        NonGiftable = 2,
        Giftable = 1,
        None = 0
    }
}
