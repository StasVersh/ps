using System.Collections.Generic;
using System.Linq;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class OperationSystem
    {
        public long Scd { get; private set; }
        public int BuildingSpeed { get; private set; }
        public List<Task> Tasks { get; }

        public OperationSystem()
        {
            Scd = 0;
            BuildingSpeed = 5;
            Tasks = new List<Task>();
        }
        
        public void AccrueScd(long value)
        {
            Scd += value;
            EventHandler.OperationSystem.Invoke();
        }

        public bool WriteOffScd(int value)
        {
            if(value > Scd) return false;
            Scd -= value;
            EventHandler.OperationSystem.Invoke();
            return true;
        }
        
        public void AddTask(Task task)
        {
            Tasks.Add(task);
            EventHandler.OperationSystem.Invoke();
        }

        public void RemoveTask()
        {
            Tasks.Remove(Tasks.First());
            EventHandler.OperationSystem.Invoke();
        }
        
        public void IncreaseBuildingSpeed()
        {
            BuildingSpeed += 5;
            EventHandler.OperationSystem.Invoke();
        }
    }
}