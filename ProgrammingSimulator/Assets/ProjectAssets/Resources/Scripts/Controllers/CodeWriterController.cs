using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class CodeWriterController : MonoBehaviour
    {
        private TMP_Text _text;
        private CodeExamples _codeExamples;
        private ScrollRect _scrollRect;
        private PlayerStats _playerStats;
        private List<char> _code = new List<char>();
        private bool _isCoding;

        [Inject]
        private void Construct(Input input, CodeExamples codeExamples, PlayerStats playerStats)
        {
            _codeExamples = codeExamples;
            _playerStats = playerStats;
            input.Coding.AddListener(UpdateText);
        }


        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
            _scrollRect = gameObject.transform.parent.parent.GetComponent<ScrollRect>();
            EventHandler.CurrentApp.AddListener(CurrentWindowChanging);
        }

        private void CurrentWindowChanging(App state)
        {
            _isCoding = state is App.SCode;
        }


        private void UpdateText()
        {
            if(!_isCoding) return;
            if (_code.IsEmpty()) _code = GetNewCodeExample();
            var currentIndex = _playerStats.TypingSpeed;
            while (currentIndex > 0)
            {
                _text.text += _code.First();
                _code.RemoveAt(0);
                if (_code.IsEmpty()) _code =  GetNewCodeExample();
                if (_code.First() != ' ' && _code.First() != '\n') currentIndex--;
                _playerStats.IncreaseSymbolsByOne();
                _scrollRect.normalizedPosition = new Vector2(0, 0);
            }
        }

        private List<char> GetNewCodeExample()
        {
            return _codeExamples.BinaryCode[Random.Range(0, _codeExamples.BinaryCode.Count - 1)]
                .ToString()
                .ToCharArray()
                .ToList();
        }
    }
}