using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PangLib.IFF.Models.Data;

namespace Pangya_Modern_Editor.Extensions
{
    public class Util
    {
        public Util()
        {
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder stringBuilder = new StringBuilder(checked(ba.Length * 2));
            foreach (byte b in ba)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }

        public static string ByteToString(byte ba)
        {
            StringBuilder stringBuilder = new StringBuilder(2);
            stringBuilder.AppendFormat("{0:x2}", ba);
            return stringBuilder.ToString();
        }

        public static object lerArquivo(string arquivo, ref byte[] Inicio, ref long Qtd, int totalB)
        {
            //Discarded unreachable code: IL_00ca, IL_00d6
            byte[] array = File.ReadAllBytes(arquivo);
            List<byte> list = new List<byte>();
            List<string> list2 = new List<string>();
            int num = 1;
            int num2 = 0;
            checked
            {
                int num3 = array.Length - 1;
                int num4 = 0;
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    if (num4 < 8)
                    {
                        list.Add(array[num4]);
                    }
                    list2.Add(ByteToString(array[num4]));
                    num4++;
                }
                Inicio = list.ToArray();
                string value = ByteToString(list[3]) + ByteToString(list[2]) + ByteToString(list[1]) + ByteToString(list[0]);
                Qtd = Convert.ToInt32(value, 16);
                if (Conversions.ToBoolean(verificarEstrutura(array.Length, (int)Qtd, totalB)))
                {
                    return list2;
                }
                return false;
            }
        }

        public static object lerArquivoCauldron(string arquivo, ref byte[] Inicio, ref long Qtd, int totalB)
        {
            //Discarded unreachable code: IL_00b0, IL_00bc
            byte[] array = File.ReadAllBytes(arquivo);
            List<byte> list = new List<byte>();
            List<string> list2 = new List<string>();
            int num = 1;
            int num2 = 0;
            checked
            {
                int num3 = array.Length - 1;
                int num4 = 0;
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    if (num4 < 8)
                    {
                        list.Add(array[num4]);
                    }
                    list2.Add(ByteToString(array[num4]));
                    num4++;
                }
                Inicio = list.ToArray();
                string value = ByteToString(list[1]) + ByteToString(list[0]);
                Qtd = Convert.ToInt32(value, 16);
                if (Conversions.ToBoolean(verificarEstrutura(array.Length, (int)Qtd, totalB)))
                {
                    return list2;
                }
                return false;
            }
        }

        public static object verificarEstrutura(int bytes, int qtd, int total)
        {
            //Discarded unreachable code: IL_0031, IL_003d
            checked
            {
                double number = (double)(bytes + 8) / (double)total;
                if ((Conversion.Int(number) < (double)(qtd + 100)) & (Conversion.Int(number) > (double)(qtd - 100)))
                {
                    return true;
                }
                return false;
            }
        }

        public static object StringToByte(string Str)
        {
            ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
            return aSCIIEncoding.GetBytes(Str);
        }

        public static string HexToString(string hex)
        {
            string text = "";
            checked
            {
                int num = hex.Length - 2;
                int num2 = 0;
                while (true)
                {
                    int num3 = num2;
                    int num4 = num;
                    if (num3 > num4)
                    {
                        break;
                    }
                    char c = Strings.Chr(Convert.ToByte(hex.Substring(num2, 2), 16));
                    text += Conversions.ToString(c);
                    num2 += 2;
                }
                return Strings.RTrim(text.ToString());
            }
        }

        public static bool checkN(string s)
        {
            if (s == null)
            {
                return false;
            }
            s = s.Trim(Conversions.ToChar(new string('\0', 1)));
            return string.IsNullOrEmpty(s);
        }

        public static List<List<string>> dividirArquivo(List<string> Lista, int tamanho)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> list2 = new List<string>();
            List<byte> list3 = new List<byte>();
            int num = 0;
            int num2 = 0;
            checked
            {
                int num3 = Lista.Count - 1;
                int num4 = 0;
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    if (num4 >= 8)
                    {
                        if (num < tamanho - 1)
                        {
                            num++;
                        }
                        else
                        {
                            num2++;
                            num = 0;
                        }
                        list2.Add(Lista[num4]);
                        if (unchecked(num == 0 && num2 > 0))
                        {
                            list.Add(list2);
                            list2 = new List<string>();
                        }
                    }
                    num4++;
                }
                return list;
            }
        }

        //public static object findItemName(List<Part> Lista, string Valor)
        //{
           
        //    List<Part> list = new List<Part>();
        //    checked
        //    {
        //        int num = Lista.Count - 1;
        //        int num2 = 0;
        //        while (true)
        //        {
        //            int num3 = num2;
        //            int num4 = num;
        //            if (num3 > num4)
        //            {
        //                break;
        //            }
        //            if (Lista[num2].ItemName.ToLower().Contains(Valor.ToLower()))
        //            {
        //                list.Add(Lista[num2]);
        //            }
        //            num2++;
        //        }
        //        return list;
        //    }
        //}

        public static bool gravarArquivo(byte[] Bs, string caminho, ref BackgroundWorker BW)
        {
            //Discarded unreachable code: IL_0053, IL_0084, IL_008b, IL_00a6
            try
            {
                BW.ReportProgress(1);
            }
            catch (Exception projectError)
            {
                ProjectData.SetProjectError(projectError);
                ProjectData.ClearProjectError();
            }
            try
            {
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                File.WriteAllBytes(caminho, Bs);
                MessageBox.Show("Arquivo salvo com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                MessageBox.Show("Erro ao gravar o arquivo: " + ex2.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                bool result = false;
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static bool gravarArquivoDividido(byte[] Bs, string caminho)
        {
            //Discarded unreachable code: IL_0026, IL_0039, IL_0040
            try
            {
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                }
                File.WriteAllBytes(caminho, Bs);
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                bool result = false;
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static object gerarBackup(byte[] bs, string caminho, bool Data = true, int TotalProc = 0)
        {
            //Discarded unreachable code: IL_0088, IL_00a1, IL_00a8
            try
            {
                TotalProc = 1;
                string fileName = Path.GetFileName(caminho);
                string text = Path.GetDirectoryName(caminho) + "\\";
                string path = ((!Data) ? (text + fileName + ".bak") : (text + DateAndTime.Now.ToString("ddMMyyyy_HHmmss_") + fileName + ".bak"));
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                TotalProc = 30;
                File.WriteAllBytes(path, bs);
                TotalProc = 100;
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                object result = false;
                ProjectData.ClearProjectError();
                return result;
            }
        }

        public static string Bytes_To_String(byte[] bytes_Input)
        {
            string text = "";
            int upperBound = bytes_Input.GetUpperBound(0);
            int num = 0;
            while (true)
            {
                int num2 = num;
                int num3 = upperBound;
                if (num2 > num3)
                {
                    break;
                }
                text += int.Parse(bytes_Input[num].ToString()).ToString("X").PadLeft(2, '0');
                num = checked(num + 1);
            }
            return text;
        }

        public static object String_TO_Bytes(string Str)
        {
            List<byte> list = new List<byte>();
            byte[] bytes = Encoding.Default.GetBytes(Str);
            byte[] array = bytes;
            foreach (byte b in array)
            {
                list.Add(Convert.ToByte(b.ToString("x").ToUpper(), 16));
            }
            while (list.Count < 40)
            {
                list.Add(default(byte));
            }
            return list.ToArray();
        }

        public static object Long_TO_Bytes(long Num)
        {
            List<byte> list = new List<byte>();
            string text = Conversion.Hex(Num);
            string text2 = "";
            string text3 = "";
            int num = Strings.Len(text) % 2;
            if (num == 1)
            {
                text = "0" + text;
            }
            while (Strings.Len(text) < 8)
            {
                text = "0" + text;
            }
            int num2 = Strings.Len(text);
            int num3 = 1;
            while (true)
            {
                int num4 = num3;
                int num5 = num2;
                if (num4 > num5)
                {
                    break;
                }
                text3 = Strings.Mid(text, num3, 2);
                list.Add(Convert.ToByte(text3.PadRight(2, '0'), 16));
                text2 = text3.PadRight(2, '0') + text2;
                num3 = checked(num3 + 2);
            }
            byte[] array = list.ToArray();
            Array.Reverse(array);
            return array;
        }

        public static object Short_TO_Bytes(short Num)
        {
            List<byte> list = new List<byte>();
            string text = Conversion.Hex(Num);
            string text2 = "";
            string text3 = "";
            int num = Strings.Len(text) % 2;
            if (num == 1)
            {
                text = "0" + text;
            }
            while (Strings.Len(text) < 4)
            {
                text = "0" + text;
            }
            int num2 = Strings.Len(text);
            int num3 = 1;
            while (true)
            {
                int num4 = num3;
                int num5 = num2;
                if (num4 > num5)
                {
                    break;
                }
                text3 = Strings.Mid(text, num3, 2);
                list.Add(Convert.ToByte(text3.PadRight(2, '0'), 16));
                text2 = text3.PadRight(2, '0') + text2;
                num3 = checked(num3 + 2);
            }
            byte[] array = list.ToArray();
            Array.Reverse(array);
            return array;
        }

        public static object Byte_To_Hex(byte Num)
        {
            List<byte> list = new List<byte>();
            string text = Conversion.Hex(Num);
            int num = Strings.Len(text) % 2;
            if (num == 1)
            {
                text = "0" + text;
            }
            return Convert.ToByte(text.PadRight(2, '0'), 16);
        }

        public static object setValues(object Itens, byte[] Inicio, long qtdItens, bool BytesVazios = true)
        {
            List<byte> list = new List<byte>();
            string text = "";
            int num = 0;
            int num2 = 0;
            list.AddRange((IEnumerable<byte>)Long_TO_Bytes(qtdItens));
            list.Add(Convert.ToByte("0B", 16));
            list.Add(default(byte));
            list.Add(default(byte));
            list.Add(default(byte));
            int num3 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(Itens, null, "Count", new object[0], null, null, null), 1));
            int num4 = 0;
            checked
            {
                short num7 = default(short);
                long num10 = default(long);
                byte b = default(byte);
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null));
                    PropertyInfo[] properties = objectValue.GetType().GetProperties();
                    PropertyInfo[] array = properties;
                    foreach (PropertyInfo propertyInfo in array)
                    {
                        if (Operators.CompareString(propertyInfo.PropertyType.Name, num7.GetType().Name, false) == 0)
                        {
                            short num8 = Conversions.ToShort(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array2 = (byte[])Short_TO_Bytes(num8);
                            byte[] array3 = array2;
                            foreach (byte item in array3)
                            {
                                list.Add(item);
                            }
                            num2 += 2;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, text.GetType().Name, false) == 0)
                        {
                            string str = Conversions.ToString(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array4 = (byte[])String_TO_Bytes(str);
                            int num9 = 0;
                            byte[] array5 = array4;
                            foreach (byte item2 in array5)
                            {
                                list.Add(item2);
                                num9++;
                            }
                            num2 += 40;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, num10.GetType().Name, false) == 0)
                        {
                            long num11 = Conversions.ToLong(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            string text2 = Conversion.Hex(num11);
                            byte[] array6 = (byte[])Long_TO_Bytes(num11);
                            byte[] array7 = array6;
                            foreach (byte item3 in array7)
                            {
                                list.Add(item3);
                            }
                            num2 += 4;
                        }
                        else
                        {
                            if (Operators.CompareString(propertyInfo.PropertyType.Name, b.GetType().Name, false) != 0)
                            {
                                throw new Exception("Tipo de propriedade não encontrada");
                            }
                            byte num12 = Conversions.ToByte(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte item4 = Conversions.ToByte(Byte_To_Hex(num12));
                            list.Add(item4);
                            num2++;
                        }
                    }
                    num4++;
                }
                return list.ToArray();
            }
        }

        public static object setValuesCalderao(object Itens, byte[] Inicio, long qtdItens, bool BytesVazios = true)
        {
            List<byte> list = new List<byte>();
            string text = "";
            int num = 0;
            int num2 = 0;
            checked
            {
                list.AddRange((IEnumerable<byte>)Short_TO_Bytes((short)qtdItens));
                list.Add(Inicio[2]);
                list.Add(Inicio[3]);
                list.Add(Inicio[4]);
                list.Add(Inicio[5]);
                list.Add(Inicio[6]);
                list.Add(Inicio[7]);
                int num3 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(Itens, null, "Count", new object[0], null, null, null), 1));
                int num4 = 0;
                short num7 = default(short);
                long num10 = default(long);
                byte b = default(byte);
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null));
                    PropertyInfo[] properties = objectValue.GetType().GetProperties();
                    PropertyInfo[] array = properties;
                    foreach (PropertyInfo propertyInfo in array)
                    {
                        if (Operators.CompareString(propertyInfo.PropertyType.Name, num7.GetType().Name, false) == 0)
                        {
                            short num8 = Conversions.ToShort(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array2 = (byte[])Short_TO_Bytes(num8);
                            byte[] array3 = array2;
                            foreach (byte item in array3)
                            {
                                list.Add(item);
                            }
                            num2 += 2;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, text.GetType().Name, false) == 0)
                        {
                            string str = Conversions.ToString(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array4 = (byte[])String_TO_Bytes(str);
                            int num9 = 0;
                            byte[] array5 = array4;
                            foreach (byte item2 in array5)
                            {
                                list.Add(item2);
                                num9++;
                            }
                            num2 += 40;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, num10.GetType().Name, false) == 0)
                        {
                            long num11 = Conversions.ToLong(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            string text2 = Conversion.Hex(num11);
                            byte[] array6 = (byte[])Long_TO_Bytes(num11);
                            int num12 = 0;
                            byte[] array7 = array6;
                            foreach (byte item3 in array7)
                            {
                                if (num12 < 4)
                                {
                                    list.Add(item3);
                                    num12++;
                                }
                            }
                            num2 += 4;
                        }
                        else
                        {
                            if (Operators.CompareString(propertyInfo.PropertyType.Name, b.GetType().Name, false) != 0)
                            {
                                throw new Exception("Tipo de propriedade não encontrada");
                            }
                            byte num13 = Conversions.ToByte(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte item4 = Conversions.ToByte(Byte_To_Hex(num13));
                            list.Add(item4);
                            num2++;
                        }
                    }
                    num4++;
                }
                return list.ToArray();
            }
        }

        public static object setValuesDividido(object Itens, int qtdItens)
        {
            List<byte> list = new List<byte>();
            string text = "";
            int num = 0;
            int num2 = 0;
            list.AddRange((IEnumerable<byte>)Long_TO_Bytes(qtdItens));
            list.Add(Convert.ToByte("0B", 16));
            list.Add(default(byte));
            list.Add(default(byte));
            list.Add(default(byte));
            int num3 = Conversions.ToInteger(Operators.SubtractObject(NewLateBinding.LateGet(Itens, null, "Count", new object[0], null, null, null), 1));
            int num4 = 0;
            checked
            {
                short num7 = default(short);
                long num10 = default(long);
                byte b = default(byte);
                while (true)
                {
                    int num5 = num4;
                    int num6 = num3;
                    if (num5 > num6)
                    {
                        break;
                    }
                    object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null));
                    PropertyInfo[] properties = objectValue.GetType().GetProperties();
                    PropertyInfo[] array = properties;
                    foreach (PropertyInfo propertyInfo in array)
                    {
                        if (Operators.CompareString(propertyInfo.PropertyType.Name, num7.GetType().Name, false) == 0)
                        {
                            short num8 = Conversions.ToShort(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array2 = (byte[])Short_TO_Bytes(num8);
                            byte[] array3 = array2;
                            foreach (byte item in array3)
                            {
                                list.Add(item);
                            }
                            num2 += 2;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, text.GetType().Name, false) == 0)
                        {
                            string str = Conversions.ToString(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte[] array4 = (byte[])String_TO_Bytes(str);
                            int num9 = 0;
                            byte[] array5 = array4;
                            foreach (byte item2 in array5)
                            {
                                list.Add(item2);
                                num9++;
                            }
                            num2 += 40;
                        }
                        else if (Operators.CompareString(propertyInfo.PropertyType.Name, num10.GetType().Name, false) == 0)
                        {
                            long num11 = Conversions.ToLong(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            string text2 = Conversion.Hex(num11);
                            byte[] array6 = (byte[])Long_TO_Bytes(num11);
                            byte[] array7 = array6;
                            foreach (byte item3 in array7)
                            {
                                list.Add(item3);
                            }
                            num2 += 4;
                        }
                        else
                        {
                            if (Operators.CompareString(propertyInfo.PropertyType.Name, b.GetType().Name, false) != 0)
                            {
                                throw new Exception("Tipo de propriedade não encontrada");
                            }
                            byte num12 = Conversions.ToByte(propertyInfo.GetValue(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(Itens, new object[1] { num4 }, null)), null));
                            byte item4 = Conversions.ToByte(Byte_To_Hex(num12));
                            list.Add(item4);
                            num2++;
                        }
                    }
                    num4++;
                }
                return list.ToArray();
            }
        }

        //public static object Part_gerarSql(List<Part> lista, string Arquivo, ref BackgroundWorker BW)
        //{
        //    //Discarded unreachable code: IL_0249
        //    BW.ReportProgress(0);
        //    string text = "";
        //    StreamWriter streamWriter = new StreamWriter(Arquivo, true);
        //    text += "USE [Pangya_S4_TH]\r\n";
        //    text += "GO\r\n\r\n";
        //    List<char> list = new List<char>();
        //    int num = 0;
        //    checked
        //    {
        //        foreach (Part listum in lista)
        //        {
        //            num++;
        //            double a = 100.0 * ((double)num / (double)lista.Count);
        //            BW.ReportProgress((int)Math.Round(a));
        //            int num2 = 0;
        //            if (listum.MoneyFlag != 2)
        //            {
        //                num2 = 1;
        //            }
        //            string text2 = listum.ItemName.Replace("\0", "");
        //            string text3 = listum.Icon.Replace("\0", "");
        //            string text4 = Conversions.ToString(listum.ItemID);
        //            string text5 = Conversions.ToString(listum.Price);
        //            string text6 = Conversions.ToString(listum.MoneyFlag);
        //            string text7 = Conversions.ToString(listum.ItemType);
        //            string text8 = Conversions.ToString(num2);
        //            text += "-- PART: {0}\r\n";
        //            text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
        //            text += "BEGIN\r\n";
        //            text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
        //            text += "\t\tNAME = '{0}'";
        //            text += "\t\t,ICON = '{2}' ";
        //            text += "\t\t,PRICE = {3}";
        //            text += "\t\t,ISCASH = {4}";
        //            text += "\t\t,TYPE = {5}";
        //            text += "\t\t,IS_SALABLE = {6} ";
        //            text += "\t WHERE TYPEID = {1}\r\n";
        //            text += "END\r\nELSE\r\nBEGIN\r\n";
        //            text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
        //            text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
        //            text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}','{6}')\r\n";
        //            text += "END\r\n\r\n";
        //            text = string.Format(text, text2, text4, text3, text5, text6, text7, text8);
        //            streamWriter.Write(text);
        //            text = "";
        //        }
        //        streamWriter.Close();
        //        return true;
        //    }
        //}

        //public static object Item_gerarSql(List<Item> lista, string Arquivo, ref BackgroundWorker BW)
        //{
        //    //Discarded unreachable code: IL_023f
        //    BW.ReportProgress(0);
        //    string text = "";
        //    StreamWriter streamWriter = new StreamWriter(Arquivo, true);
        //    text += "USE [Pangya_S4_TH]\r\n";
        //    text += "GO\r\n\r\n";
        //    List<char> list = new List<char>();
        //    int num = 0;
        //    checked
        //    {
        //        foreach (Item listum in lista)
        //        {
        //            num++;
        //            double a = 100.0 * ((double)num / (double)lista.Count);
        //            BW.ReportProgress((int)Math.Round(a));
        //            int num2 = 0;
        //            if (listum.MoneyFlag != 2)
        //            {
        //                num2 = 1;
        //            }
        //            string text2 = listum.ItemName.Replace("\0", "");
        //            string text3 = listum.Icon.Replace("\0", "");
        //            string text4 = Conversions.ToString(listum.ItemID);
        //            string text5 = Conversions.ToString(listum.Price);
        //            string text6 = Conversions.ToString(listum.MoneyFlag);
        //            string text7 = Conversions.ToString(num2);
        //            text += "-- ITEM: {0}\r\n";
        //            text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
        //            text += "BEGIN\r\n";
        //            text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
        //            text += "\t\tNAME = '{0}'";
        //            text += "\t\t,ICON = '{2}' ";
        //            text += "\t\t,PRICE = {3}";
        //            text += "\t\t,ISCASH = {4}";
        //            text += "\t\t,TYPE = {5}";
        //            text += "\t\t,IS_SALABLE = {6} ";
        //            text += "\t WHERE TYPEID = {1}\r\n";
        //            text += "END\r\nELSE\r\nBEGIN\r\n";
        //            text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
        //            text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
        //            text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}','{6}')\r\n";
        //            text += "END\r\n\r\n";
        //            text = string.Format(text, text2, text4, text3, text5, text6, 0, text7);
        //            streamWriter.Write(text);
        //            text = "";
        //        }
        //        streamWriter.Close();
        //        return true;
        //    }
        //}

        //public static object SetItem_gerarSql(List<SetItem> lista, string Arquivo, ref BackgroundWorker BW)
        //{
        //    //Discarded unreachable code: IL_023f
        //    BW.ReportProgress(0);
        //    string text = "";
        //    StreamWriter streamWriter = new StreamWriter(Arquivo, true);
        //    text += "USE [Pangya_S4_TH]\r\n";
        //    text += "GO\r\n\r\n";
        //    List<char> list = new List<char>();
        //    int num = 0;
        //    checked
        //    {
        //        foreach (SetItem listum in lista)
        //        {
        //            num++;
        //            double a = 100.0 * ((double)num / (double)lista.Count);
        //            BW.ReportProgress((int)Math.Round(a));
        //            int num2 = 0;
        //            if (listum.MoneyFlag != 2)
        //            {
        //                num2 = 1;
        //            }
        //            string text2 = listum.ItemName.Replace("\0", "");
        //            string text3 = listum.Icon.Replace("\0", "");
        //            string text4 = Conversions.ToString(listum.ItemID);
        //            string text5 = Conversions.ToString(listum.Price);
        //            string text6 = Conversions.ToString(listum.MoneyFlag);
        //            string text7 = Conversions.ToString(num2);
        //            text += "-- SETITEM: {0}\r\n";
        //            text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
        //            text += "BEGIN\r\n";
        //            text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
        //            text += "\t\tNAME = '{0}'";
        //            text += "\t\t,ICON = '{2}' ";
        //            text += "\t\t,PRICE = {3}";
        //            text += "\t\t,ISCASH = {4}";
        //            text += "\t\t,TYPE = {5}";
        //            text += "\t\t,IS_SALABLE = {6} ";
        //            text += "\t WHERE TYPEID = {1}\r\n";
        //            text += "END\r\nELSE\r\nBEGIN\r\n";
        //            text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
        //            text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
        //            text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}','{6}')\r\n";
        //            text += "END\r\n\r\n";
        //            text = string.Format(text, text2, text4, text3, text5, text6, 0, text7);
        //            streamWriter.Write(text);
        //            text = "";
        //        }
        //        streamWriter.Close();
        //        return true;
        //    }
        //}

        //public static object ClubSet_gerarSql(List<ClubSet> lista, string Arquivo, ref BackgroundWorker BW)
        //{
            
        //    BW.ReportProgress(0);
        //    string text = "";
        //    StreamWriter streamWriter = new StreamWriter(Arquivo, true);
        //    text += "USE [Pangya_S4_TH]\r\n";
        //    text += "GO\r\n\r\n";
        //    List<char> list = new List<char>();
        //    int num = 0;
        //    checked
        //    {
        //        foreach (ClubSet listum in lista)
        //        {
        //            num++;
        //            double a = 100.0 * ((double)num / (double)lista.Count);
        //            BW.ReportProgress((int)Math.Round(a));
        //            int num2 = 0;
        //            if (listum.MoneyFlag != 2)
        //            {
        //                num2 = 1;
        //            }
        //            string text2 = listum.ItemName.Replace("\0", "");
        //            string text3 = listum.Icon.Replace("\0", "");
        //            string text4 = Conversions.ToString(listum.ItemID);
        //            string text5 = Conversions.ToString(listum.Price);
        //            string text6 = Conversions.ToString(listum.MoneyFlag);
        //            string text7 = Conversions.ToString(num2);
        //            text += "-- CLUBSET: {0}\r\n";
        //            text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
        //            text += "BEGIN\r\n";
        //            text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
        //            text += "\t\tNAME = '{0}'";
        //            text += "\t\t,ICON = '{2}' ";
        //            text += "\t\t,PRICE = {3}";
        //            text += "\t\t,ISCASH = {4}";
        //            text += "\t\t,TYPE = {5}";
        //            text += "\t\t,IS_SALABLE = {6} ";
        //            text += "\t WHERE TYPEID = {1}\r\n";
        //            text += "END\r\nELSE\r\nBEGIN\r\n";
        //            text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
        //            text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
        //            text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}','{6}')\r\n";
        //            text += "END\r\n\r\n";
        //            text = string.Format(text, text2, text4, text3, text5, text6, 0, text7);
        //            streamWriter.Write(text);
        //            text = "";
        //        }
        //        streamWriter.Close();
        //        return true;
        //    }
        //}

        public static object Caddie_gerarSql(List<Caddie> lista, string Arquivo, ref BackgroundWorker BW)
        {
            
            BW.ReportProgress(0);
            string text = "";
            StreamWriter streamWriter = new StreamWriter(Arquivo, true);
            text += "USE [Pangya_S4_TH]\r\n";
            text += "GO\r\n\r\n";
            List<char> list = new List<char>();
            int num = 0;
            checked
            {
                foreach (Caddie listum in lista)
                {
                    num++;
                    double a = 100.0 * ((double)num / (double)lista.Count);
                    BW.ReportProgress((int)Math.Round(a));
                    int num2 = 0;
                    if ((int)listum.MoneyFlag != 2)
                    {
                        num2 = 1;
                    }
                    string text2 = listum.Name.Replace("\0", "");
                    string text3 = listum.Icon.Replace("\0", "");
                    string text4 = Conversions.ToString(listum.ID);
                    string text5 = Conversions.ToString(listum.Price);
                    string text6 = Conversions.ToString(listum.MoneyFlag);
                    string text7 = Conversions.ToString(num2);
                    text += "-- CLUBSET: {0}\r\n";
                    text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
                    text += "BEGIN\r\n";
                    text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
                    text += "\t\tNAME = '{0}'";
                    text += "\t\t,ICON = '{2}' ";
                    text += "\t\t,PRICE = {3}";
                    text += "\t\t,ISCASH = {4}";
                    text += "\t\t,TYPE = {5}";
                    text += "\t\t,IS_SALABLE = {6} ";
                    text += "\t WHERE TYPEID = {1}\r\n";
                    text += "END\r\nELSE\r\nBEGIN\r\n";
                    text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
                    text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
                    text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}','{6}')\r\n";
                    text += "END\r\n\r\n";
                    text = string.Format(text, text2, text4, text3, text5, text6, 0, text7);
                    streamWriter.Write(text);
                    text = "";
                }
                streamWriter.Close();
                return true;
            }
        }

        //public static object CaddieItem_gerarSql(List<CaddieItem> lista, string Arquivo, ref BackgroundWorker BW)
        //{
            
        //    BW.ReportProgress(0);
        //    string text = "";
        //    StreamWriter streamWriter = new StreamWriter(Arquivo, true);
        //    text += "USE [Pangya_S4_TH]\r\n";
        //    text += "GO\r\n\r\n";
        //    List<char> list = new List<char>();
        //    int num = 0;
        //    checked
        //    {
        //        foreach (CaddieItem listum in lista)
        //        {
        //            num++;
        //            double a = 100.0 * ((double)num / (double)lista.Count);
        //            BW.ReportProgress((int)Math.Round(a));
        //            int num2 = 0;
        //            if (listum.MoneyFlag != 2)
        //            {
        //                num2 = 1;
        //            }
        //            string text2 = listum.ItemName.Replace("\0", "");
        //            string text3 = listum.Icon.Replace("\0", "");
        //            string text4 = Conversions.ToString(listum.ItemID);
        //            string text5 = Conversions.ToString(listum.Price);
        //            string text6 = Conversions.ToString(listum.MoneyFlag);
        //            string text7 = Conversions.ToString(num2);
        //            text += "-- CLUBSET: {0}\r\n";
        //            text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
        //            text += "BEGIN\r\n";
        //            text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
        //            text += "\t\tNAME = '{0}'";
        //            text += "\t\t,ICON = '{2}' ";
        //            text += "\t\t,PRICE = {3}";
        //            text += "\t\t,ISCASH = {4}";
        //            text += "\t\t,TYPE = {5}";
        //            text += "\t\t,IS_SALABLE = {6} ";
        //            text += "\t WHERE TYPEID = {1}\r\n";
        //            text += "END\r\nELSE\r\nBEGIN\r\n";
        //            text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
        //            text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
        //            text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}','{6}')\r\n";
        //            text += "END\r\n\r\n";
        //            text = string.Format(text, text2, text4, text3, text5, text6, 0, text7);
        //            streamWriter.Write(text);
        //            text = "";
        //        }
        //        streamWriter.Close();
        //        return true;
        //    }
        //}

        //public static object Ball_gerarSql(List<Ball> lista, string Arquivo, ref BackgroundWorker BW)
        //{
        //    BW.ReportProgress(0);
        //    string text = "";
        //    StreamWriter streamWriter = new StreamWriter(Arquivo, true);
        //    text += "USE [Pangya_S4_TH]\r\n";
        //    text += "GO\r\n\r\n";
        //    List<char> list = new List<char>();
        //    int num = 0;
        //    checked
        //    {
        //        foreach (Ball listum in lista)
        //        {
        //            num++;
        //            double a = 100.0 * ((double)num / (double)lista.Count);
        //            BW.ReportProgress((int)Math.Round(a));
        //            int num2 = 0;
        //            if (listum.MoneyFlag != 2)
        //            {
        //                num2 = 1;
        //            }
        //            string text2 = listum.ItemName.Replace("\0", "");
        //            string text3 = listum.Icon.Replace("\0", "");
        //            string text4 = Conversions.ToString(listum.ItemID);
        //            string text5 = Conversions.ToString(listum.Price);
        //            string text6 = Conversions.ToString(listum.MoneyFlag);
        //            string text7 = Conversions.ToString(num2);
        //            text += "-- BALL: {0}\r\n";
        //            text += "IF EXISTS ( SELECT TYPEID FROM PANGYA_ITEM_TYPELIST WHERE TYPEID = {1} ) \r\n";
        //            text += "BEGIN\r\n";
        //            text += "\tUPDATE PANGYA_ITEM_TYPELIST SET \r\n";
        //            text += "\t\tNAME = '{0}'";
        //            text += "\t\t,ICON = '{2}' ";
        //            text += "\t\t,PRICE = {3}";
        //            text += "\t\t,ISCASH = {4}";
        //            text += "\t\t,IS_SALABLE = {5} ";
        //            text += "\t WHERE TYPEID = {1}\r\n";
        //            text += "END\r\nELSE\r\nBEGIN\r\n";
        //            text += "\tINSERT INTO PANGYA_ITEM_TYPELIST\r\n";
        //            text += "\t ( [TYPEID], [NAME], [ICON], [PRICE], [ISCASH],[TYPE], [IS_SALABLE] )\r\n";
        //            text += "\tVALUES ('{1}','{0}','{2}','{3}','{4}','{5}')\r\n";
        //            text += "END\r\n\r\n";
        //            text = string.Format(text, text2, text4, text3, text5, text6, text7);
        //            streamWriter.Write(text);
        //            text = "";
        //        }
        //        streamWriter.Close();
        //        return true;
        //    }
        //}
    }

}
