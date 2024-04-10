using System;
using System.Runtime.InteropServices;
using PangLib.IFF.JP.Models.Flags;
namespace PangLib.IFF.JP.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public class IFFLevel
    {
        [field: MarshalAs(UnmanagedType.U1, SizeConst = 1)]
        private ItemLevelEnum _level;//ler somente esse ;D

        public bool GoodLevel(byte _stlevel)
        {
            if (is_max && _stlevel <= level)
                return true;
            else if (!is_max && _stlevel >= level)
                return true;

            return false;
        }
        public byte level
        {
            get
            {
                return (byte)_level;
            }
            set
            {
                if (value > 70)
                {
                    value = 70;
                }
                _level =(ItemLevelEnum)value;
            }
        }
        /// <summary>
        /// set value in level max, true = 70, false = other value
        /// </summary>
        public bool is_max
        {
            get { return (level & 0b01000000) != 0; }
            set
            {
                if (value)
                {
                    var new_level = level;
                    level = Convert.ToByte((new_level |= 0b01000000) - 55);
                }
                else
                    level &= 0b00111111;
            }
        }

    }
}
