using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public static class EventHandler
    {
        public static UnityEvent SCode = new UnityEvent();
        public static UnityEvent OperationSystem = new UnityEvent();
        public static UnityEvent Store = new UnityEvent();
        public static UnityEvent<App> CurrentApp = new UnityEvent<App>();
        public static UnityEvent<Building> BuildingEnd = new UnityEvent<Building>();
    }
}