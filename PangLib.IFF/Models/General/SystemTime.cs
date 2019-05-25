using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SystemTime
    {
        public ushort Year { get; set; }
        public ushort Month { get; set; }
        public ushort DayOfWeek { get; set; }
        public ushort Day { get; set; }
        public ushort Hour { get; set; }
        public ushort Minute { get; set; }
        public ushort Second { get; set; }
        public ushort MilliSecond { get; set; }
    }
}
