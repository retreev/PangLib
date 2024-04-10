using PangLib.IFF.Models.Flags;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct SetEffectTable.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetEffectTable
    {
        public uint ID { get; set; }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class Effect
        {
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public eEFFECT[] effect { get; set; } // eEFFECT = Effect[0~2] é o da descrição em cima
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public eEFFECT_TYPE[] type { get; set; }// eEFFECT_TYPE = type[0~2], 2 Game, 4 Room e 8 Lounge
        }
        [field: MarshalAs(UnmanagedType.Struct)]
        public Effect effect { get; set; }
        [StructLayout(LayoutKind.Sequential, Pack = 1)]

        public class Item
        {
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public uint[] TypeID { get; set; }
            [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            public byte[] Active { get; set; }
            public bool IsActive(int idx)
            {
                return Active[idx] > 0;
            }
        }
        [field: MarshalAs(UnmanagedType.Struct)]
        public Item item { get; set; }
        public byte Slot { get; set; }
        public byte Effect_Add_Power { get; set; }   // Força sem penalidade
    }
    #endregion
}
