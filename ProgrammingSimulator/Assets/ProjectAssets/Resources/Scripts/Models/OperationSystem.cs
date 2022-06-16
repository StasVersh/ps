using System.Collections.Generic;
using System.Linq;
using ProjectAssets.Resources.Scripts.Structures;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class OperationSystem
    {
        public long Scd { get; private set; }
        public int BuildingSpeed { get; private set; }
        public List<ITask> Tasks { get; private set; }

        public OperationSystem()
        {
            Scd = 0;
            BuildingSpeed = 5;
            Tasks = new List<ITask>();
        }
        
        public void StructToModel(OperationSystemStruct @struct)
        {
            Scd = @struct.Scd;
            BuildingSpeed = @struct.BuildingSpeed;
            EventHandler.OperationSystem.Invoke();
        }
        
        public OperationSystemStruct ModelToSruct()
        {
            return new OperationSystemStruct
            {
                Scd = Scd,
                BuildingSpeed = BuildingSpeed,
            };
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
        
        public void AddTask(ITask task)
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