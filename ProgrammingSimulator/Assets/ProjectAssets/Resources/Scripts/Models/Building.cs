namespace ProjectAssets.Resources.Scripts.Models
{
    public class Building : Task
    {
        public override void End(PlayerStats playerStats)
        {
            playerStats.AccrueScd(playerStats.Symbols * playerStats.ConversionPrice);
            playerStats.ResetSymbols();
        }
    }
}