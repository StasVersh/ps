using System.Collections.Generic;
using System.Linq;
using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        private Input _input;

        private readonly List<KeyCode> _codeKeyCodes = new List<KeyCode>()
        {
            KeyCode.A,
            KeyCode.B,
            KeyCode.C,
            KeyCode.D,
            KeyCode.E,
            KeyCode.F,
            KeyCode.G,
            KeyCode.H,
            KeyCode.I,
            KeyCode.J,
            KeyCode.K,
            KeyCode.L,
            KeyCode.M,
            KeyCode.N,
            KeyCode.O,
            KeyCode.P,
            KeyCode.Q,
            KeyCode.R,
            KeyCode.S,
            KeyCode.T,
            KeyCode.U,
            KeyCode.V,
            KeyCode.W,
            KeyCode.X,
            KeyCode.Y,
            KeyCode.Z,
        };

        [Inject]
        private void Construct(Input input)
        {
            _input = input;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift) & UnityEngine.Input.GetKey(KeyCode.LeftControl) &
                UnityEngine.Input.GetKey(KeyCode.LeftAlt) & UnityEngine.Input.GetKey(KeyCode.Return))
            {
                Prefs.ResetAllPrefs();
                SceneManager.LoadScene(Scenes.BootMenu.ToString());
            }
            else if (UnityEngine.Input.GetKey(KeyCode.LeftShift) & UnityEngine.Input.GetKey(KeyCode.B))
            {
                _input.Build.Invoke();
            }
            else
            {
                foreach (var keyCode in _codeKeyCodes.Where(UnityEngine.Input.GetKeyDown))
                {
                    _input.Coding.Invoke();
                }
            }
        }
    }
}
