using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Utilities;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers.OS
{
    public class BuildingEndAlertController : MonoBehaviour
    {
        [SerializeField] private ModalWindowManager _modalWindow;
        private Input _input;

        [Inject]
        private void Construct(Input input)
        {
            _input = input;
        }
        
        private void Start()
        {
            EventHandler.BuildingEnd.AddListener(BuildingEnd);
            _input.Complite.AddListener(Close);
        }

        private void Close()
        {
            if (_modalWindow == null) return;
            _modalWindow.CloseWindow();
        }

        private void BuildingEnd(Building building)
        {
            if (building.Probability >= 1) ShowGuaranteedSuccessfullyDialog(building);
            else if (building.IsSuccessfully) ShowSuccessfullyDialog(building);
            else ShowFailDialog(building);
        }

        private void ShowFailDialog(Building building)
        {
            if (_modalWindow == null) return;
            _modalWindow.titleText = "Fail";
            _modalWindow.descriptionText =
                "You took a chance, but your gut let you down. Everything will have to be rewritten. " +
                $"The probability of success was {Mathf.Round(building.Probability * 100)}%. ";
            _modalWindow.OpenWindow();
            _modalWindow.UpdateUI();
        }

        private void ShowSuccessfullyDialog(Building building)
        {
            if (_modalWindow == null) return;
            _modalWindow.titleText = "Successfully";
            _modalWindow.descriptionText = "You took a chance, your gut didn't let you down. " +
                                           $"The probability of success was {Mathf.Round(building.Probability * 100)}%. " +
                                           $"You have earned an {CoinsConvertor.ToMinString(building.Symbols * building.ConversionPrice)} SCD";
            _modalWindow.OpenWindow();
            _modalWindow.UpdateUI();
        }

        private void ShowGuaranteedSuccessfullyDialog(Building building)
        {
            if (_modalWindow == null) return;
            _modalWindow.titleText = "Successfully";
            _modalWindow.descriptionText = "Your code has been successfully compiled and you have received " +
                                           $"{CoinsConvertor.ToMinString(building.Symbols * building.ConversionPrice)} SCD";
            _modalWindow.OpenWindow();
            _modalWindow.UpdateUI();
        }
    }
}