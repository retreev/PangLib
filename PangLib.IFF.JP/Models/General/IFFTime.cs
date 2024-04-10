using System;
using System.Runtime.InteropServices;
namespace PangLib.IFF.JP.Models.General
{
    /// <summary>
    /// System time structure based on Windows internal SYSTEMTIME struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public class IFFTime
    {
        /// <summary>
        /// Year
        /// </summary>
        public ushort Year { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        public ushort Month { get; set; }

        /// <summary>
        /// Day of Week
        /// </summary>
        public ushort DayOfWeek { get; set; }

        /// <summary>
        /// Day
        /// </summary>
        public ushort Day { get; set; }

        /// <summary>
        /// Hour
        /// </summary>
        public ushort Hour { get; set; }

        /// <summary>
        /// Minute
        /// </summary>
        public ushort Minute { get; set; }

        /// <summary>
        /// Second
        /// </summary>
        public ushort Second { get; set; }

        /// <summary>
        /// Millisecond
        /// </summary>
        public ushort MilliSecond { get; set; }

        public bool TimeActive
        {
            get
            {
                return Year > 0 && Month > 0 && Day > 0;
            }
        }

        public DateTime Time
        {
            get
            {
                if (TimeActive)//normal item
                {
                    return new DateTime(Year, Month, Day, Hour, Minute, Second, MilliSecond);
                }
                //for grand prix :D
                else if(Hour > 0 || Minute > 0)
                {

                    var value = DateTime.Now; Year = (ushort)value.Year;
                    Month = (ushort)value.Month;
                    DayOfWeek = (ushort)value.DayOfWeek;
                    Day = (ushort)value.Day;
                    return new DateTime(value.Year, value.Month, value.Day, Hour, Minute, 0, 0);//aqui tem que setar, dia mes e ano
                }
                return DateTime.Now;
            }
            set
            {
                Year = (ushort)value.Year;
                Month = (ushort)value.Month;
                DayOfWeek = (ushort)value.DayOfWeek;
                Day = (ushort)value.Day;
                Hour = (ushort)value.Hour;
                Minute = (ushort)value.Minute;
                MilliSecond = (ushort)value.Millisecond == 0? (ushort)DateTime.Now.Millisecond: (ushort)value.Millisecond;
                Second = (ushort)value.Second;
            }
        }
        public DateTime TimeGP
        {
            get
            {
                var value = DateTime.Now;
         
                Year = (ushort)value.Year;
                Month = (ushort)value.Month;
                DayOfWeek = (ushort)value.DayOfWeek;
                Day = (ushort)value.Day;
                return new DateTime(value.Year, value.Month, Day, Hour, Minute, 0, 0);//aqui tem que setar, dia mes e ano
            }
            set
            {
                Year = (ushort)value.Year;
                Month = (ushort)value.Month;
                DayOfWeek = (ushort)value.DayOfWeek;
                Day = (ushort)value.Day;
                Hour = (ushort)value.Hour;
                Minute = (ushort)value.Minute;
                MilliSecond = (ushort)value.Millisecond == 0 ? (ushort)DateTime.Now.Millisecond : (ushort)value.Millisecond;
                Second = (ushort)value.Second;
            }
        }

        public void ClearTime()
        {
            Year = 0;
            Month = 0;
            DayOfWeek = 0;
            Day = 0;
            Hour = 0;
            Minute = 0;
            Second = 0;
        }

        public string ToString(string format)
        {
            return Time.ToString(format);
        }

        public IFFTime()
        { }
        public IFFTime
            (DateTime date)
        {
            Time = date;
        }

    }
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 36)]
    public class IFFDate
    {
        public IFFDate()
        {
            Start = new IFFTime();
            End = new IFFTime();
        }
        //-------------------- TIME IFF--------------\\
        public uint active { get; set; }//156 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime Start { get; set; }// 160 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime End { get; set; }// 176 start position
        //--------------------------------------------------\\
        public bool Check()
        {
            return (DateTime.Compare(Start.Time, DateTime.Now) < 0) & (DateTime.Compare(End.Time, DateTime.Now) > 0);
        }
    }
}
