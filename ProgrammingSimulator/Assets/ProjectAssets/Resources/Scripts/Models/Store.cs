using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Structures;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Store
    {
        public int TypingSpeedLevel { get; private set; }
        public int BookOnProgrammingLevel { get; private set; }
        public int CourseOurSelfPriceLevel { get; private set; }
        public int BuildingSpeedLevel { get; private set; }

        public Store()
        {
            TypingSpeedLevel = 1;
            BookOnProgrammingLevel = 1;
            CourseOurSelfPriceLevel = 1;
            BuildingSpeedLevel = 1;
        }
        
        public void StructToModel(StoreStruct @struct)
        {
            TypingSpeedLevel = @struct.TypingSpeedLevel;
            BookOnProgrammingLevel = @struct.BookOnProgrammingLevel;
            CourseOurSelfPriceLevel = @struct.CourseOurSelfPriceLevel;
            BuildingSpeedLevel = @struct.BuildingSpeedLevel;
            EventHandler.Store.Invoke();
        }
        
        public StoreStruct ModelToSruct()
        {
            return new StoreStruct
            {
                TypingSpeedLevel = TypingSpeedLevel,
                BookOnProgrammingLevel = BookOnProgrammingLevel,
                CourseOurSelfPriceLevel = CourseOurSelfPriceLevel,
                BuildingSpeedLevel = BuildingSpeedLevel
            };
        }

        public void IncreaseTypingSpeedLevel()
        {
            TypingSpeedLevel += 1;
            EventHandler.Store.Invoke();
        }
        
        public void IncreaseBookOnProgrammingLevel()
        {
            BookOnProgrammingLevel += 1;
            EventHandler.Store.Invoke();
        }
        
        public void IncreaseCourseOurSelfPriceLevel()
        {
            CourseOurSelfPriceLevel += 1;
            EventHandler.Store.Invoke();
        }
        
        public void IncreaseBuildingSpeedLevel()
        {
            BuildingSpeedLevel += 1;
            EventHandler.Store.Invoke();
        }

        public int GetValueOnType(StorePoints storePoints)
        {
            return storePoints switch
            {
                StorePoints.TypingSpeed => TypingSpeedLevel,
                StorePoints.BookOnProgramming => BookOnProgrammingLevel,
                StorePoints.CourseOurSelfPrice => CourseOurSelfPriceLevel,
                StorePoints.NewProcessor => BuildingSpeedLevel,
                _ => 1
            };
        }
    }
}