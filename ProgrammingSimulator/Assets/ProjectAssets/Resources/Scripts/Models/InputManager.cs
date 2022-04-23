using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class InputManager
    {
        public UnityEvent OnClick { get; }
        public UnityEvent OnBuild { get; }
        public UnityEvent OnEnter { get; }
        
        public InputManager()
        {
            OnClick = new UnityEvent();
            OnBuild = new UnityEvent();
            OnEnter = new UnityEvent();
        }
    }
}