namespace ProjectAssets.Resources.Scripts.Models
{
    public class Building : ITask
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public long Symbols { get; }
        public int ConversionPrice { get; }
        public float Probability { get; }
        public bool IsSuccessfully { get; }

        public Building(int speed, long symbols, int conversionPrice, float probability, bool isSuccessfully)
        {
            Speed = speed;
            Symbols = symbols;
            ConversionPrice = conversionPrice;
            Probability = probability;
            IsSuccessfully = isSuccessfully;
            Name = "Building";
        }

        public void End(OperationSystem os)
        {
            if(IsSuccessfully) os.AccrueScd(Symbols * ConversionPrice);
        }
    }
}