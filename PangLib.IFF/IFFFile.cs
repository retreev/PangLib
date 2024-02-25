using PangLib.IFF.Extensions;
using PangLib.IFF.Models.General;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
namespace PangLib.IFF
{
    /// <summary>
    /// new version create By LuisMK D:
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public partial class IFFFile<T> : List<T>
    {
        /// <summary>
        /// Header IFF(cabeçario do IFF, contem Contagem dos itens existentes no *.iff, ID de ligacao, Versão do IFF 
        /// </summary>
        public IFFHeader Header { get; set; } = new IFFHeader();
        /// <summary>
        /// Atualiza o IFF/Update for IFF
        /// </summary>
        public bool Update { get; set; }
        public IFFFile()
        {
            Header = new IFFHeader();
            Update = false;
        }

        /// <summary>
        /// class construtor(classe construtura do IFFList)
        /// </summary>
        /// <param name="path">local onde fica o arquivo/ local</param>
        public IFFFile(string path)
        {
            Header = new IFFHeader();
            Update = false;
            if (File.Exists(path))
                Load(File.ReadAllBytes(path));
        }

        public bool CheckVersionIFF()
        {
            if (Header.Version == 13)
            {
                return true;
            }
            else if (Header.Version == 13)
            {
                throw new Exception(
                      $"[IFFFile::Error]: version-incompatible file structure: ({Marshal.SizeOf((T)Activator.CreateInstance(typeof(T)))})");

            }
            else if (Header.Version != 13)
            {
                throw new Exception($"[IFFFile::Error]:" +
                    $"Version Actual: 13 \n " +
                    $"Version File: {Header.Version} \n" +
                    $"Version-incompatible file structure\n");
            }
            else
            {
                throw new Exception($"[IFFFile::Error]: Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual");
            }
        }

        public virtual string GetItemName(uint TypeID)
        {
            try
            {
                foreach (var item in this)
                {
                    if (item is IFFCommon)//verifica se IFFCommon
                    {
                        var item2 = item as IFFCommon;
                        if (item2.ID == TypeID)
                        {
                            return item2.Name;
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch { return ""; }
            return "";
        }

        /// <summary>
        ///so obtem se for IFFCommon
        /// </summary>
        /// <param name="TypeID"></param>
        /// <returns>retorna o tipo</returns>
        public T GetItem(uint TypeID)
        {
            foreach (var item in this)
            {
                if (item is IFFCommon)//verifica se IFFCommon
                {
                    var item2 = item as IFFCommon;
                    if (item2.ID == TypeID)
                    {
                        return item;
                    }
                }
                else
                {
                    return CreateItem();
                }
            }
            return CreateItem();
        }

        public IFFCommon GetItemCommon(uint TypeID)
        {
            foreach (var item in this)
            {
                if (item is IFFCommon)//verifica se IFFCommon
                {
                    var item2 = item as IFFCommon;
                    if (item2.ID == TypeID)
                    {
                        return item2;
                    }
                }
                else
                {
                    return new IFFCommon().CreateNewItem();
                }
            }
            return new IFFCommon().CreateNewItem();
        }

        public virtual uint GetPrice(uint TypeID)
        {
            return GetItemCommon(TypeID).Shop.Price;
        }

        public virtual sbyte GetShopPriceType(uint TypeID)
        {
            return (sbyte)GetItemCommon(TypeID).Shop.flag_shop.ShopFlag;
        }

        public virtual bool IsBuyable(uint TypeID)
        {
            var item = GetItemCommon(TypeID);
            if (item.Active == 1 && item.Shop.flag_shop.MoneyFlag == 0 || (int)item.Shop.flag_shop.MoneyFlag == 1 || (int)item.Shop.flag_shop.MoneyFlag == 2)
            {
                return true;
            }
            return false;
        }

        public virtual bool IsExist(uint TypeID)
        {
            var item = GetItemCommon(TypeID);

            return Convert.ToBoolean(item.Active);
        }

        public virtual bool LoadItem(uint ID, ref T item)
        {
            if (!this.TryGetValue(ID, out T value))
            {
                return false;
            }
            item = value;
            return true;
        }

        public virtual bool TryGetValue(uint ID, out T value)
        {
            if (GetItem(ID) != null)
            {
                value = GetItem(ID);
                return true;
            }
            value = CreateItem();
            return false;
        }

        public new void AddRange(IEnumerable<T> item)
        {
            var OldCount = Count;
            base.AddRange(item);
            if (Count > Header.Count)//so atualiza se o  contador for maior
            {
                Header.Count = (short)Count;
                Update = true;
            }
        }
        public new void Add(T item)
        {
            base.Add(item);
            if (Count > Header.Count)//so atualiza se o  contador for maior
            {
                Header.Count = (short)Count;
                Update = true;
            }
        }

        public bool CheckItemSize(long size)
        {
            long recordLength = (size - 8L) / Header.Count;
            if (recordLength != Marshal.SizeOf(CreateItem()))
            {
                throw new Exception(
                    $"The record({CreateItem().GetType().Name}) length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(CreateItem())})");
            }
            return true;
        }

        /// <summary>
        /// parses the *.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the *.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public virtual void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));
                Header = Reader.Read<IFFHeader>();
                CheckVersionIFF();
                CheckItemSize(Reader.GetSize());
                for (int i = 0; i < Header.Count; i++)
                {
                    //reader object and convert is class IFF
                    var item = (T)Reader.Read(CreateItem());
                    //add item in List<T>
                    Add(item);
                }
            }
            catch
            {
                //show log error :(
               
            }
            finally
            {
                //is dispose memory :D
                Reader.Dispose();
            }
        }
        public virtual void Load(byte[] data, int _count)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                for (int i = 0; i < _count; i++)
                {
                    //reader object and convert is class IFF
                    var item = (T)Reader.Read(CreateItem());
                    //add item in List<T>
                    Add(item);
                }
            }
            catch
            {
                //show log error :(
               
            }
            finally
            {
                //is dispose memory :D
                Reader.Dispose();
            }
        }


        /// <summary>
        /// save list load in iff 
        /// </summary>
        /// <param name="filePath">local file</param>
        /// <summary>
        /// Save a IFFFile instance to a file
        /// </summary>
        /// <param name="filePath">File path to save the IFF file to</param>
        public void Save(string filePath)
        {
            try
            {
                using (PangyaBinaryWriter writer = new PangyaBinaryWriter())
                {
                    writer.WriteStruct(Header);
                    foreach (var entry in this)
                    {
                        writer.WriteStruct(entry);
                    }
                    writer.WriteFile(filePath);
                    Update = false;
                }
            }
            catch
            {
               
            }
        }
        public byte[] GetBytes()
        {
            try
            {
                var size = Marshal.SizeOf(CreateItem());
                var bytes = new byte[size];
                // Crie um stream para armazenar os bytes serializados
                using (PangyaBinaryWriter stream = new PangyaBinaryWriter())
                {
                    // Crie um formateador binário
                    foreach (var item in this)
                    {
                        stream.WriteStruct(item);
                    }
                    // Obtenha os bytes do stream
                    bytes = stream.GetBytes;
                }
                return bytes;
            }
            catch
            {
                return new byte[0];
            }
        }

        public byte[] GetBytes(int index)
        {
            try
            {
                var size = Marshal.SizeOf(CreateItem());
                var bytes = new byte[size];
                // Crie um stream para armazenar os bytes serializados
                using (PangyaBinaryWriter stream = new PangyaBinaryWriter())
                {
                    // Crie um formateador binário
                    var item = this[index];
                    stream.WriteStruct(item);

                    // Obtenha os bytes do stream
                    bytes = stream.GetBytes;
                }
                return bytes;
            }
            catch
            {
                return new byte[0];
            }
        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        protected virtual T CreateItem()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public virtual int GetSize()
        {
            return Marshal.SizeOf(CreateItem());
        }

        ~IFFFile()
        {
        }
    }
    
}
