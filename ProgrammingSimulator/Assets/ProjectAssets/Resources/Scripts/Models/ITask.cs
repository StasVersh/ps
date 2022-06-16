namespace ProjectAssets.Resources.Scripts.Models
{
    public interface ITask
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public void End(OperationSystem os);
    }
}