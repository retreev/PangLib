using PangLib.IFF.Models.General;
using PangLib.IFF.Models.Flags;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PangLib.IFF.Models.Data
{
    #region Struct CadieMagicBox.iff
    [Serializable]
    public class CadieMagicBoxA : CadieMagicBox, ICloneable
    {
        public object Clone()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            return binaryFormatter.Deserialize(memoryStream);
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CadieMagicBox 
    {
        public uint MagicID { get; set; }//index
        public uint Enabled { get; set; }//valido
        public CadieBoxSetor Page { get; set; }//showOnPage
        public CadieBoxEnum BoxType { get; set; }//
        public uint Level { get; set; }//okay
        public uint ProdItem { get; set; }
        public uint TypeID { get; set; }
        public uint Quatity { get; set; }
        //

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] TradeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] TradeQuantity { get; set; }
        public uint Box_Random_ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        byte[] NameInBytes { get; set; }//8 start position
        public string Name { get => Encoding.UTF7.GetString(NameInBytes); set => NameInBytes = Encoding.UTF7.GetBytes(value.PadRight(40, '\0')); }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime Start { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime End { get; set; }
        public bool Check()
        {
            return (DateTime.Compare(Start.Time, DateTime.Now) < 0) & (DateTime.Compare(End.Time, DateTime.Now) > 0);
        }
    }
    #endregion
}
