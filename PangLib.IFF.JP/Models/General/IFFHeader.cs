using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace PangLib.IFF.JP.Models.General
{
    /// <summary>
    /// Have Struct for IFF Header/ Contem a estrutura do IFF Cabecario
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public class IFFHeader
    {
        /// <summary>
        /// size file data
        /// </summary>
        public short Count { get; set; }

        /// <summary>
        /// ID determining relation to other IFF files
        /// </summary>
        public short BindingID { get; set; }

        /// <summary>
        /// Version of this IFF file
        /// </summary>
        public uint Version { get; set; }
        /// <summary>
        /// Construtor/Construção
        /// </summary>
        public IFFHeader()
        {

        }
    }
}
