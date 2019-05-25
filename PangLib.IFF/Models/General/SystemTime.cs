using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort MilliSecond;
    }
}
