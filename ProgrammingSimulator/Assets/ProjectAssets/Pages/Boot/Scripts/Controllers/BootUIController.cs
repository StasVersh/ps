using ProjectAssets.Resources.Scripts.Values;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ProjectAssets.Pages.Boot.Scripts.Controllers
{
    public class BootUIController : MonoBehaviour
    {
        [Inject]
        private void Construct(BootUI bootUI)
        {
            bootUI.SDos.onClick.AddListener(StartSDos);
            bootUI.SavaDoors.onClick.AddListener(StartSavaDoors);
        }

        private static void StartSavaDoors()
        {
            SceneManager.LoadSceneAsync(Scenes.SavaDoors);
        }

        private static void StartSDos()
        {
            SceneManager.LoadSceneAsync(Scenes.SDos);
        }
    }
}