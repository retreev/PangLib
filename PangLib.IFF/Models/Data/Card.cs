using System.Runtime.InteropServices;
using PangLib.IFF.Models.Flags;
using PangLib.IFF.Models.General;

namespace PangLib.IFF.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Card
    {
        [MarshalAs(UnmanagedType.Struct)]
        public IFFCommon Header;
        public byte Rarity;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture;
        public ushort PowerSlot;
        public ushort ControlSlot;
        public ushort AccuracySlot;
        public ushort SpinSlot;
        public ushort CurveSlot;
        public CardEffectFlag Effect;
        public ushort EffectValue;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture3;
        public ushort EffectTime;
        public ushort Volume;
        public ushort CardID;
    }
}
