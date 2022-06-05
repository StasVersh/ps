namespace ProjectAssets.Resources.Scripts.Models
{
    public class ListTile
    {
        public int Level { get; }
        public string Header { get; }
        public string Description { get; }
        public int Coast { get; }
        public bool IsEnable { get; }
        
        public ListTile(int level, string header, string description, int coast, bool isEnable)
        {
            Level = level;
            Header = header;
            Description = description;
            Coast = coast;
            IsEnable = isEnable;
        }
    }
}