using System.IO;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PangLib.IFF.Models.Flags;
using PangLib.IFF.Extensions;

namespace PangLib.IFF.Models.General
{
    /// <summary>
    /// Ref's:
    /// my code first: https://github.com/oung/Py_Source_JP/tree/master/Src/PangyaFileCore
    ///<code></code>
    /// replace: https://github.com/Acrisio-Filho/SuperSS-Dev/blob/master/Server%20Lib/Projeto%20IOCP/TYPE/data_iff.h
    /// update in 30/06/2023 - 10:40 AM by LuisMK
    ///<code></code>
    /// Common data structure found at the head of many IFF datasets
    ///<code></code>
    /// Size 192 bytes    ?
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial class IFFCommon : ICloneable
    {
        //------------------- IFF BASIC ----------------------------\\
        public uint Active { get; set; }//0 start position
        public uint ID { get; set; }//4 start position
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }//8 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 1)]
        public IFFLevel Level { get; set; }//72 start position
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 43)]
        public string Icon { get; set; }//73 start position
        //--------------------------end--------------------------------\\

        //------------------ SHOP DADOS ---------------------------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFShopData Shop { get; set; } = new IFFShopData();
        //-------------------  END  ------------------------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 24)]
        public IFFTikiShopData tiki { get; set; } = new IFFTikiShopData();
        //-------------------- TIME IFF--------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 36)]
        public IFFDate date { get; set; } = new IFFDate();
        /// <summary>
        /// voce pode carregar qualquer iff(que contem o Base)
        /// </summary>
        /// <param name="reader">binario de leitura</param>
        /// <param name="LenghtStr">tamanho do string name</param>
        public void Load(ref PangyaBinaryReader reader, uint LenghtStr, long recordLength = 0, uint version = 11, bool jump = false)
        {
            //------------------- IFF BASIC ----------------------------\\
            Active = reader.ReadUInt32();
            ID = reader.ReadUInt32();
            Name = reader.ReadPStr(LenghtStr);
            Level = new IFFLevel
            {
                level = reader.ReadByte() //49 start position
            };
            Icon = reader.ReadPStr(43); //89 start position
            //--------------------------end--------------------------------\\
            //------------------ SHOP DADOS ---------------------------------\\
            Shop = (IFFShopData)reader.Read(new IFFShopData());
            //-------------------  END  ------------------------------\\
            //------------------ Tiki SHOP---------------------\\
            if (version != 11)
            {
                tiki = (IFFTikiShopData)reader.Read(new IFFTikiShopData());
            }
            //-----------------------------------------------\\

            //-------------------- TIME IFF--------------\\
            date = (IFFDate)reader.Read(new IFFDate());
            //--------------------------------------------------\\
            if (jump)
            {
                reader.BaseStream.Seek(8L + (recordLength), SeekOrigin.Begin);
            }
        }
        /// <summary>
        /// Envia uma notificao ao Editor/Dev 
        /// voce não pode listar este item pois o valor ira 
        /// ativar um codigo no ProjectG de alerta
        /// </summary>
        public void SendMessage()
        {
            bool result = Shop.flag_shop.can_send_mail_and_personal_shop
             || Shop.flag_shop.block_mail_and_personal_shop
             || Shop.flag_shop.is_saleable;
            if (result && Shop.Price >= 1000000)
                MessageBox.Show($"\nBe careful, you activated an item, but did not change its value\n check this item({ID})", "Pangya Editor v2", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }


        public string GetItemName()
        {
            return Name;
        }
        public int ShopFlag
        {
            get { return (int)(Shop == null ? 0 : Shop.flag_shop.ShopFlag); }
            set
            {
                Shop.flag_shop.ShopFlag = (ShopFlag)value;
            }
        }
        public int MoneyFlag
        {
            get { return (int)(Shop == null ? 0 : Shop.flag_shop.MoneyFlag); }
            set
            {
                Shop.flag_shop.MoneyFlag = (MoneyFlag)value;
            }
        }
        public uint Price
        {
            get => Shop == null ? 0 : Shop.Price;
            set => Shop.Price = value;
        }
        public byte ItemLevel
        {
            get => (byte)(Level == null ? 0 : Level.level);
            set => Level.level = value;
        }
        public uint DiscountPrice
        {
            get => Shop == null ? 0 : Shop.DiscountPrice;
            set => Shop.DiscountPrice = value;
        }
        public sbyte GetShopPriceType()
        {
            return (sbyte)Shop.flag_shop.ShopFlag;
        }

        public bool IsBuyable()
        {
            if (Active == 1 && Shop.flag_shop.MoneyFlag == 0 || (int)Shop.flag_shop.MoneyFlag == 1 || (int)Shop.flag_shop.MoneyFlag == 2)
            {
                return true;
            }
            return false;
        }

        public bool IsNormal()
        {
            return Active == 1 && Shop.flag_shop.IsNormal || Shop.flag_shop.is_saleable;
        }
        public bool IsExist()
        {
            return Convert.ToBoolean(Active);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        public IFFCommon()
        {
            Name = "[NEW ITEM] by LuisMK";
            Icon = "Icon.tga";
            date = new IFFDate();
            tiki = new IFFTikiShopData();
            Shop = new IFFShopData();
        }
        //conversion this 
        public virtual IFFCommon CreateNewItem()
        {
            Name = "[NEW ITEM] by LuisMK";
            Icon = "[NEW ICON] by LuisMK";
            date = new IFFDate();
            tiki = new IFFTikiShopData();
            Shop = new IFFShopData();
            return this;
        }

        public uint TypeItem()
        {
            return (uint)(int)Math.Round((ID & 0xFC000000) / Math.Pow(2.0, 26.0));
        }

        public bool IsDupItem()
        {
            return (Active == 1 && Shop.flag_shop.IsDuplication);
        }

        public bool IsSellItem()
        {
            return (Active == 1 && Shop.flag_shop.is_saleable);
        }

        public bool IsGiftItem()
        {
            // É saleable ou giftable nunca os 2 juntos por que é a flag composta Somente Purchase(compra)
            // então faço o xor nas 2 flag se der o valor de 1 é por que ela é um item que pode presentear
            // Ex: 1 + 1 = 2 Não é
            // Ex: 1 + 0 = 1 OK
            // Ex: 0 + 1 = 1 OK
            // Ex: 0 + 0 = 0 Não é
            byte is_giftable = Convert.ToByte(Shop.flag_shop.IsGift);
            byte _is_saleable = Convert.ToByte(Shop.flag_shop.is_saleable);
            return (Active == 1 && Shop.flag_shop.IsTypeCash
                    && (_is_saleable ^ is_giftable) == 1);
        }

        public bool IsOnlyDisplay()
        {
            return (Active == 1 && Shop.flag_shop.IsDisplay);
        }

        public bool IsOnlyPurchase()
        {
            return (Active == 1 && Shop.flag_shop.is_saleable
                    && Shop.flag_shop.IsGift);
        }

        public bool IsOnlyGift()
        {
            return (Active == 1 && Shop.flag_shop.IsTypeCash
                    && Shop.flag_shop.is_saleable && Shop.flag_shop.IsGift == false);
        }

        public bool IsPSQ()
        {
            return (Active == 1 && Shop.flag_shop.can_send_mail_and_personal_shop || Shop.flag_shop.IsPSQ || Shop.flag_shop.IsTradeable);
        }
        /// <summary>
        /// verifica é pang, cookie ou esta oculto dentro do shopping
        /// </summary>
        /// <returns>0= cookies, 1= pang, 2= hide </returns>
        public int GetTypeCash()
        {
            //se testar o flag do tipo de moeda antes, não vai dar certo
            //tem que testar o flag hide primeiro
            var result = Shop.flag_shop.IsHide ? 2 : Shop.flag_shop.IsTypeCash ? 0 : 1;
            return result;
        }


    }
}
