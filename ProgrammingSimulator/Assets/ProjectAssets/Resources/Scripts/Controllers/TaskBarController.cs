using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

public class TaskBarController : MonoBehaviour
{
    private Taskbar _taskbar;
    private Notepad _notepad;

    [Inject]
    private void Construct(OS os)
    {
        _taskbar = os.Desctop.Taskbar;
        _notepad = os.Notepad;
        AddListeners();
    }

    private void AddListeners()
    {
        _taskbar.Notepad.onClick.AddListener(OnNotepadButtonClick);
    }

    private void OnNotepadButtonClick()
    {
        _notepad.GameObject.SetActive(!_notepad.IsOpen);
        _notepad.IsOpen = !_notepad.IsOpen;
    }
}
