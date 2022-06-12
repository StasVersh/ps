namespace ProjectAssets.Resources.Scripts.Models
{
    public abstract class Task
    {
        public string Name;
        public int Speed;
        public abstract void End(OperationSystem os);
    }
}