using PangLib.IFF.Models.Flags;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace PangLib.IFF.Models.General
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public partial class IFFShopData
    {
        public uint Price { get; set; }//116 start position
        public uint DiscountPrice { get; set; }//120 start position
        public uint UsedPrice { get; set; }//124 start position(Aqui é a condição do angel wing seu valor é 6, as outras angel wings do outros characters variam entre 1, 5, 6 e 0 (acho que seja a sexta condição de quit rate menor que 3%)
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 4)]
        public FlagShop flag_shop { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 4)]
    public class FlagShop
    {
        /// <summary>
        /// shop flag
        /// </summary>
        public ShopFlag ShopFlag { get; set; }//128 start position
        public MoneyFlag MoneyFlag { get; set; }//129 start position(0x01 in stock; 0x02 disable gift; 0x03 Special; 0x08 new; 0x10 hot)
        //-------------------- TIME IFF--------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 2)]
        public TimeShop time_shop { get; set; }
        //-------------------- TIME IFF--------------\\      
        /// <summary>
        /// true = cookie, false is Pang
        /// </summary>
        public bool IsCash
        {
            get { return ((int)ShopFlag & 0b00000001) != 0; }
        }
        /// <summary>
        /// IsReserve
        /// </summary>
        public bool can_send_mail_and_personal_shop
        {
            get { return ((int)ShopFlag & 0b00000010) != 0; }
        }

        public bool IsDuplication
        {
            get { return ((int)ShopFlag & 0b00000100) != 0; }
        }

        public bool IsSpecial
        {

            get => (ShopFlag == (ShopFlag)0x20 && MoneyFlag == (MoneyFlag)3) || (ShopFlag == (ShopFlag)0x21 && MoneyFlag == (MoneyFlag)3);
        }
        /// <summary>
        /// IsNew
        /// </summary>
        public bool block_mail_and_personal_shop
        {
            get { return ((int)ShopFlag & 0b00010000) != 0; }
        }
        /// <summary>
        /// is hot ou sale
        /// </summary>
        public bool is_saleable
        {
            get { return ((int)ShopFlag & 0b00100000) != 0; }
        }

        public bool IsGift
        {
            get { return ShopFlag == Flags.ShopFlag.Combine99 || ShopFlag == Flags.ShopFlag.Combine96 || ShopFlag == Flags.ShopFlag.Combine || ShopFlag == Flags.ShopFlag.Combine98; }
        }

        public bool IsDisplay
        {
            get { return  ShopFlag == Flags.ShopFlag.Only_Display || ShopFlag == Flags.ShopFlag.Display; }
        }

        public bool IsNormal
        {

            get
            {
                return (ShopFlag == (ShopFlag)98 && MoneyFlag == 0) || (ShopFlag == (ShopFlag)0x20 && MoneyFlag == 0) || (ShopFlag == (ShopFlag)21 && MoneyFlag == 0);
            }
        }
        public bool IsHide
        {
            get
            {
                return can_send_mail_and_personal_shop == false
                   & IsDuplication == false & IsSpecial == false & block_mail_and_personal_shop == false
                   & is_saleable == false & IsGift == false & IsDisplay == false && IsPSQ == false;
            }
        }
        public bool IsHot
        {
            get
            {
                return (ShopFlag == (ShopFlag)0x20 && MoneyFlag == (MoneyFlag)2) || (ShopFlag == (ShopFlag)0x21 && MoneyFlag == (MoneyFlag)2);
            }
        }

        public bool IsTradeable
        {
            get
            {
                return ShopFlag == (ShopFlag)6 && MoneyFlag == 0 && IsCash == false;
            }
            
        }

        public bool IsNew { get => (ShopFlag == (ShopFlag)4 && MoneyFlag == (MoneyFlag)1) || (ShopFlag == (ShopFlag)0x21 && MoneyFlag == (MoneyFlag)1); }
        public bool IsPSQ { get => (ShopFlag == (ShopFlag)98 && MoneyFlag == MoneyFlag.None) || (ShopFlag == (ShopFlag)7 && MoneyFlag == MoneyFlag.None); }

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
        bool Get(int value)
        {
            BitArray bits = new BitArray(BitConverter.GetBytes((short)ShopFlag));
            bits = PadToFullByte(bits);

            return bits.Get(value);
        }

        public void setFlag(int v, bool value)
        {
            BitArray bits = new BitArray(BitConverter.GetBytes((short)ShopFlag));
            bits = PadToFullByte(bits);
            bits.Set(v, value);
            ShopFlag = (ShopFlag)ConvertToByte(bits);
        }
        byte ConvertToByte(BitArray bits)
        {
            byte[] array = new byte[1];
            bits.CopyTo(array, 0);
            return array[0];
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 2)]
    public class TimeShop
    {
        [field: MarshalAs(UnmanagedType.U1, SizeConst = 1)]
        public bool active { get; set; }//130 start position(Item por tempo)
        public byte dia { get; set; }//131 start position(Tempo por dias=1, 7, 15, 30 e 365 && 0xFF fica 0x6D, por que é 0x16D = 365)
    }
}
