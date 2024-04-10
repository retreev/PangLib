using PangLib.IFF.Extensions;
using PangLib.IFF.Models.Flags;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct Ability.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Ability
    {
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Effect_Active { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public AbilityEffect[] Effect_Type { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public float[] Effect_Flag { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] Unknown_Object { get; set; }
        public uint Flag1 { get; set; }
        public uint Flag2 { get; set; }

        public Ability()
        {
        }
        public Ability(PangyaBinaryReader reader)
        {
            ID = reader.ReadUInt32();

            Effect_Active = new uint[3];
            for (int i = 0; i < 3; i++)
            {
                Effect_Active[i] = reader.ReadUInt32();
            }

            Effect_Type = new AbilityEffect[3];
            for (int i = 0; i < 3; i++)
            {
                Effect_Type[i] = (AbilityEffect)reader.ReadUInt32();
            }

            Effect_Flag = new float[3];
            for (int i = 0; i < 3; i++)
            {
                Effect_Flag[i] = reader.ReadSingle();
            }

            Unknown_Object = reader.ReadBytes(32);

            Flag1 = reader.ReadUInt32();
            Flag2 = reader.ReadUInt32();
        }
    }
    #endregion
}
