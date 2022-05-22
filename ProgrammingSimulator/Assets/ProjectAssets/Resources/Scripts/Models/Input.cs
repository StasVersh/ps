using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Input
    {
        public UnityEvent Coding { get; }
        public UnityEvent Build { get; }
        
        public Input()
        {
            Coding = new UnityEvent();
            Build = new UnityEvent();
        }
    }
}