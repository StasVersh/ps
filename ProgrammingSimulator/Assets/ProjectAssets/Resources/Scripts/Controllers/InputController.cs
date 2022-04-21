using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Pages.Desctop.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        private InputManager _inputManager;
        private List<KeyCode> _clicksKeyCodes = new List<KeyCode>()
        {
            KeyCode.Q,
            KeyCode.W,
            KeyCode.E,
            KeyCode.R,
            KeyCode.T,
            KeyCode.Y,
            KeyCode.U,
            KeyCode.I,
            KeyCode.O,
            KeyCode.P,
            KeyCode.A,
            KeyCode.S,
            KeyCode.D,
            KeyCode.F,
            KeyCode.G,
            KeyCode.H,
            KeyCode.J,
            KeyCode.K,
            KeyCode.L,
            KeyCode.Z,
            KeyCode.X,
            KeyCode.C,
            KeyCode.V,
            KeyCode.B,
            KeyCode.N,
            KeyCode.M,
        };

        [Inject]
        private void Construct(InputManager inputManager)
        {
            _inputManager = inputManager;
        }
        
        private void Update()
        {
            foreach (KeyCode keyCode in _clicksKeyCodes)
            {
                if(Input.GetKeyDown(keyCode))
                {
                    _inputManager.OnClick.Invoke();
                }
            }
        }
    }
}