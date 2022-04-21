using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class InputManager
    {
        public UnityEvent OnClick { get; }
        
        public InputManager()
        {
            OnClick = new UnityEvent();
        }
    }
}