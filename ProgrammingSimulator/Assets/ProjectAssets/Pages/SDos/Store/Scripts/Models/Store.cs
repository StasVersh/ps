namespace ProjectAssets.Pages.SDos.Store.Scripts.Models
{
    public class Store
    {
        public Skills Skills { get; }
        public Soft Soft { get; }
        public Hardwear Hardwear { get; }

        public Store(Skills skills, Soft soft, Hardwear hardwear)
        {
            Skills = skills;
            Soft = soft;
            Hardwear = hardwear;
        }
    }
}