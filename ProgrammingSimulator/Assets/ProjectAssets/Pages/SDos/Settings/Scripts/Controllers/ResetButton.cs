using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ResetButton : MonoBehaviour
    {
        private void Start()
        {
            var button = GetComponent<ButtonManager>();
            button.clickEvent.AddListener(Reset);
        }

        private void Reset()
        {
            Preferences.ResetAll();
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
    }
}