using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers.OS
{
    [RequireComponent(typeof(WindowManager))]
    public class AppController : MonoBehaviour
    {
        private WindowManager _windowManager;

        [Inject]
        private void Construct(Input input)
        {
            input.NextApp.AddListener(() =>
            {
                if(_windowManager.currentWindowIndex == _windowManager.windows.Count - 1) _windowManager.OpenWindowByIndex(0);
                else _windowManager.NextWindow();
            });
        }

        private void OnEnable()
        {
            _windowManager = GetComponent<WindowManager>();
            _windowManager.onWindowChange.AddListener(OnWindowChange);
            OnWindowChange(0);
        }

        private void OnWindowChange(int window)
        {
            switch (window)  
            {
                case 0: 
                    EventHandler.CurrentApp.Invoke(App.SCode);
                    break;
                case 1: 
                    EventHandler.CurrentApp.Invoke(App.Store);
                    break;
                case 2: 
                    EventHandler.CurrentApp.Invoke(App.Setting);
                    break;
                default: 
                    EventHandler.CurrentApp.Invoke(App.None);
                    break;
            }
        }
    }
}