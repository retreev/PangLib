namespace PangLib.PET.Models
{
    public struct Version
    {
        public int Major { get; set; }
        public int Minor { get; set; }

        public override string ToString()
        {
            return $"{Major.ToString()}.{Minor.ToString()}";
        }
    }
}