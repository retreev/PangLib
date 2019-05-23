namespace PangLib.PET.Models
{
    public struct Bone
    {
        public string Name { get; set; }
        public byte Parent { get; set; }
        public float[] Matrix { get; set; }
    }
}
