using ProjectAssets.Resources.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(Button))]
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Scenes _currentScene;
        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SceneManager.LoadSceneAsync(_currentScene.ToString());
        }
    }
}