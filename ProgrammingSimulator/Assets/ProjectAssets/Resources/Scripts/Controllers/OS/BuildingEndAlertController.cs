using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Utilities;
using UnityEngine;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.OS
{
    public class BuildingEndAlertController : MonoBehaviour
    {
        [SerializeField] private ModalWindowManager _modalWindow;

        private void Start()
        {
            EventHandler.BuildingEnd.AddListener(BuildingEnd);
        }

        private void BuildingEnd(Building building)
        {
            _modalWindow.titleText = "Successfully";
            _modalWindow.descriptionText = "Your code has been successfully compiled and you have received " +
                                           $"{CoinsConvertor.ToMinString(building.Symbols * building.ConversionPrice)} SCD";
            _modalWindow.OpenWindow();
            _modalWindow.UpdateUI();
        }
    }
}