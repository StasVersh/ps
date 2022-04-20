using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Notepad
    {
        public bool IsOpen { get; set; }
        public GameObject GameObject { get; }
        
        
        public Notepad(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }
}