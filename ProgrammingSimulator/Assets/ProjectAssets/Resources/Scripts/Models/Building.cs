namespace ProjectAssets.Resources.Scripts.Models
{
    public class Building : Task
    {
        public long Symbols;
        public int ConversionPrice;
        public float Probebility;
        public bool IsSuccessfully;

        public Building(int speed, long symbols, int conversionPrice, float probebility, bool isSuccessfully)
        {
            Speed = speed;
            Symbols = symbols;
            ConversionPrice = conversionPrice;
            Probebility = probebility;
            IsSuccessfully = isSuccessfully;
            Name = "Building";
        }

        public override void End(OperationSystem os)
        {
            os.AccrueScd(Symbols * ConversionPrice);
        }
    }
}