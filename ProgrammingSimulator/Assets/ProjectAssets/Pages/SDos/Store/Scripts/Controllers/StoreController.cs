using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Pages.SDos.Store.Scripts.Controllers
{
    public class StoreController : MonoBehaviour
    {
        private Player _player;
        private Models.Store _storage;
        
        [Inject]
        private void Construct(Player player, Models.Store storage)
        {
            _player = player;
            _storage = storage;
            AddListeners();
        }

        private void AddListeners()
        {
            _storage.Skills.CoursesLevel.Button.clickEvent.AddListener(GrowUpCoursesLevel);
        }

        private void GrowUpCoursesLevel()
        {
            _storage.Skills.CoursesLevel.GrowUpLevel(_player);
        }
    }
}