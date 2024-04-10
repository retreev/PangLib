using PangLib.IFF.JP.Extensions;
using PangLib.IFF.JP.Models.Flags;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    #region Struct SetEffectTable.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetEffectTable
    {
        public SetEffectTable()
        {
        }
        public SetEffectTable(PangyaBinaryReader reader)
        {
            ID = reader.ReadUInt32();

            effect = new Effect();
            effect.effect = new eEFFECT[3];
            for (int i = 0; i < 3; i++)
            {
                effect.effect[i] = (eEFFECT)reader.ReadUInt32();
            }
            effect.type = new eEFFECT_TYPE[3];
            for (int i = 0; i < 3; i++)
            {
                effect.type[i] = (eEFFECT_TYPE)reader.ReadUInt32();
            }

            item = new Item();
            item.TypeID = new uint[5];
            for (int i = 0; i < 5; i++)
            {
                item.TypeID[i] = reader.ReadUInt32();
            }
            item.Active = new byte[5];
            for (int i = 0; i < 5; i++)
            {
                item.Active[i] = reader.ReadByte();
            }

            ucUnknown = new byte[11];
            for (int i = 0; i < 11; i++)
            {
                ucUnknown[i] = reader.ReadByte();
            }

            Slot = new short[5];
            for (int i = 0; i < 5; i++)
            {
                Slot[i] = reader.ReadInt16();
            }

            Effect_Add_Power = reader.ReadInt16();
        }

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
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[] ucUnknown { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public short[] Slot { get; set; }
        public short Effect_Add_Power { get; set; }   // Força sem penalidade
    }
    #endregion
}
