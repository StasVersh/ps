using System.IO;
using ProjectAssets.Pages.Notepad.Scripts.Models;
using UnityEngine;
using Zenject;

public class NotepadController : MonoBehaviour
{
    private Code _code;

    [Inject]
    private void Construct(Code code)
    {
        _code = code;
        _code.Text.text = File.ReadAllText("C:\\Users\\micro\\Documents\\GitHub\\ps\\ProgrammingSimulator\\Assets\\ProjectAssets\\Resources\\Code\\C#\\01.txt");
    }
}
