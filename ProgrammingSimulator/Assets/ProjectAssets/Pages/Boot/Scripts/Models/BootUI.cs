using UnityEngine.UI;

public class BootUI
{
    public Button SDos { get; }
    public Button SavaDoors { get; }

    public BootUI(Button sDoc, Button savaDoors)
    {
        SDos = sDoc;   
        SavaDoors = savaDoors;
    }
}