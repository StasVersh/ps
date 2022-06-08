using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public static class EventHandler
    {
        public static UnityEvent PlayerPrefs = new UnityEvent();
        public static UnityEvent Store = new UnityEvent();
        public static UnityEvent<App> CurrentApp = new UnityEvent<App>();
    }
}