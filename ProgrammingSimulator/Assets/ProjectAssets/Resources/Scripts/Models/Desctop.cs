using UnityEngine.UI;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Desctop
    {
        public Image Wallpapers { get; set; }
        public Taskbar Taskbar { get; set; }
        
        public Desctop(Image wallpapers, Taskbar taskbar)
        {
            Wallpapers = wallpapers;
            Taskbar = taskbar;
        }
    }
}