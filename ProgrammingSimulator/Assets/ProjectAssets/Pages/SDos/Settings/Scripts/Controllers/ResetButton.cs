using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace DefaultNamespace
{
    public class ResetButton : MonoBehaviour
    {
        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        private void Start()
        {
            var button = GetComponent<ButtonManager>();
            button.clickEvent.AddListener(Reset);
        }

        private void Reset()
        {
            Preferences.ResetAll();
            _player.Update();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}