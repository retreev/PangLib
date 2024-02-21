using PangLib.IFF.Models.Flags;
using System.Runtime.InteropServices;
namespace PangLib.IFF.Models.Data
{
    #region Struct Ability.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Ability
    {
        public uint TypeID { get; set; }
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
    }
    #endregion
}
