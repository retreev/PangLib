namespace PangLib.PET.Models
{
    public struct Version
    {
        public int Major;
        public int Minor;

        public override string ToString()
        {
            return $"{Major.ToString()}.{Minor.ToString()}";
        }
    }
}