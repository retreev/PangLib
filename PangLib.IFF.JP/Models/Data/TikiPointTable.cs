using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.Data
{
    /// <summary>
    /// Is Struct file TikiPointTable.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class TikiPointTable
    {
        public uint Index { get; set; }
        public byte TypeID { get; set; } 
		[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 35)]//is 64, 2 short unknown
        public byte[] NameInBytes { get; set; }
        public uint Qty { get; set; }
        public uint TypeID_Item { get; set; }
	 public string Name { get => Encoding.GetEncoding("Shift_JIS").GetString(NameInBytes).Replace("\0", ""); set => NameInBytes = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(35, '\0')); }
    }
}
