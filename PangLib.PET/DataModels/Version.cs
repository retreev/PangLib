namespace PangLib.PET.DataModels
{
    public class Version
    {
        public int Major;
        public int Minor;

        public override string ToString()
        {
            return $"{Major.ToString()}.{Minor.ToString()}";
        }
    }
}