namespace ProjectAssets.Resources.Scripts.Models
{
    public class OS
    {
        public Desctop Desctop { get; }
        public Notepad Notepad { get; }
        
        public OS(Desctop desctop, Notepad notepad)
        {
            Desctop = desctop;
            Notepad = notepad;
        }
    }
}