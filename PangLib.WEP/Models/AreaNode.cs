namespace PangLib.WEP.Models
{
    public struct AreaNode
    {
        public byte Type { get; set; }
        public string Sequence { get; set; }
        public Area Area { get; set; }
        public Area Area2 { get; set; }
        public ExtraValues ExtraValues { get; set; }
    }
}