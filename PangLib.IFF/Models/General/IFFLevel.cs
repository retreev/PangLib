using System;
using System.Runtime.InteropServices;
using System.Collections;
using PangLib.IFF.Models.Flags;

namespace PangLib.IFF.Models.General
{
   
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 1)]
    public class IFFLevel
    {
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
                _level =(ItemLevelEnum)value;
            }
        }
        public bool is_max
        {
            get {
                bool _is_max = false;
                BitArray bits = new BitArray(BitConverter.GetBytes(level));
                bits = PadToFullByte(bits);
                if (bits.Get(7))
                {
                    _is_max = true;
                    bits.Set(7, false);
                }
                else
                {
                    _is_max = false;
                }
                return _is_max;
            }
        }

        BitArray PadToFullByte(BitArray bits)
        {
            BitArray array = new BitArray(8, false);
            if (bits.Count > 0)
            {
                for (int i = 0; i < bits.Count; i++)
                {
                    if ((bits.Count > 8) && (i < 8))
                    {
                        array.Set(i, bits[i]);
                    }
                }
            }
            return array;
        }

        public static explicit operator int(IFFLevel v)
        {
          return  v.level;
        }
    }
}
