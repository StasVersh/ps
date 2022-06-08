using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Utilities;

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
            UpdateValuesOnPrefs();
        }

        public void UpdateValuesOnPrefs()
        {
            TypingSpeedLevel = Prefs.GetTypingSpeedLevel();
            BookOnProgrammingLevel = Prefs.GetBookOnProgrammingLevel();
            CourseOurSelfPriceLevel = Prefs.GetCourseOurSelfPriceLevel();
            BuildingSpeedLevel = Prefs.GetBuildingSpeedLevel();
        }

        public void IncreaseTypingSpeedLevel()
        {
            TypingSpeedLevel += 1;
            Prefs.SetTypingSpeedLevel(TypingSpeedLevel);
            EventHandler.Store.Invoke();
        }
        
        public void IncreaseBookOnProgrammingLevel()
        {
            BookOnProgrammingLevel += 1;
            Prefs.SetBookOnProgrammingLevel(BookOnProgrammingLevel);
            EventHandler.Store.Invoke();
        }
        
        public void IncreaseCourseOurSelfPriceLevel()
        {
            CourseOurSelfPriceLevel += 1;
            Prefs.SetCourseOurSelfPriceLevel(CourseOurSelfPriceLevel);
            EventHandler.Store.Invoke();
        }
        
        public void IncreaseBuildingSpeedLevel()
        {
            BuildingSpeedLevel += 1;
            Prefs.SetBuildingSpeedLevel(BuildingSpeedLevel);
            EventHandler.Store.Invoke();
        }

        public int GetValueOnType(StorePoints storePoints)
        {
            switch (storePoints)
            {
                case StorePoints.TypingSpeed:
                    return TypingSpeedLevel;
                case StorePoints.BookOnProgramming:
                    return BookOnProgrammingLevel;
                case StorePoints.CourseOurSelfPrice:
                    return CourseOurSelfPriceLevel;
                case StorePoints.NewProcessor:
                    return BuildingSpeedLevel;
            }

            return 1;
        }
    }
}