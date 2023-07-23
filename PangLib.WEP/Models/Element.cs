namespace PangLib.WEP.Models
{
    public struct Element
    {
        public int Unknown { get; set; }
        public int VertexCount { get; set; }
        public string Name { get; set; }
        public Matrix Matrix1 { get; set; }
        public Matrix Matrix2 { get; set; }
        public int CourseType { get; set; }
        public string ClassName { get; set; }
        public Matrix Matrix3 { get; set; }
        public ExtraValues ExtraValues { get; set; }
    }
}