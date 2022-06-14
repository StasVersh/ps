namespace ProjectAssets.Resources.Scripts.Models
{
    public class Building : Task
    {
        public long Symbols;
        public int ConversionPrice;

        public Building(int speed, long symbols, int conversionPrice)
        {
            Speed = speed;
            Symbols = symbols;
            ConversionPrice = conversionPrice;
            Name = "Building";
        }

        public override void End(OperationSystem os)
        {
            os.AccrueScd(Symbols * ConversionPrice);
        }
    }
}