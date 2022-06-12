namespace ProjectAssets.Resources.Scripts.Models
{
    public class Building : Task
    {
        private int _symbols;
        private int _conversionPrice;

        public Building(int speed, int symbols, int conversionPrice)
        {
            Speed = speed;
            _symbols = symbols;
            _conversionPrice = conversionPrice;
            Name = "Building";
        }

        public override void End(OperationSystem os)
        {
            os.AccrueScd(_symbols * _conversionPrice);
        }
    }
}