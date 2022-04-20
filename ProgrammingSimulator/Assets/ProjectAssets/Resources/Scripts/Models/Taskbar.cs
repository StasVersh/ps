using UnityEngine.UI;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Taskbar
    {
        public Button Start { get; }
        public Button Notepad { get; }
        
        public Taskbar(Button start, Button notepad)
        {
            Start = start;
            Notepad = notepad;
        }
    }
}