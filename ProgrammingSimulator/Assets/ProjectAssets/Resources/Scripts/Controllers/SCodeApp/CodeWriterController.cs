using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ModestTree;
using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;
using Input = ProjectAssets.Resources.Scripts.Models.Input;
using Random = UnityEngine.Random;

namespace ProjectAssets.Resources.Scripts.Controllers.SCodeApp
{
    [RequireComponent(typeof(TMP_Text))]
    public class CodeWriterController : MonoBehaviour
    {
        private TMP_Text _text;
        private ScrollRect _scrollRect;
        private SCode _sCode;
        private OperationSystem _os;
        private List<char> _code = new List<char>();
        private bool _isCoding;

        [Inject]
        private void Construct(Input input, SCode sCode, OperationSystem os)
        {
            _sCode = sCode;
            _os = os;
            input.Coding.AddListener(UpdateText);
        }


        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
            _scrollRect = gameObject.transform.parent.parent.GetComponent<ScrollRect>();
            EventHandler.CurrentApp.AddListener(CurrentWindowChanging);
            EventHandler.ProgrammingLanguage.AddListener(GenerateNewCodeExample);
            EventHandler.BuildingEnd.AddListener(arg0 => GenerateNewCodeExample());
        }

        private void Start()
        {
            _text.text = GetNewCodeExample(_sCode.ProgramingLanguage);
            Scrolling(0, 0);
        }

        private void CurrentWindowChanging(App state)
        {
            _isCoding = state is App.SCode;
        }
        
        private void GenerateNewCodeExample()
        {
            _text.text = GetNewCodeExample(_sCode.ProgramingLanguage);
            _code.Clear();
            Scrolling(1, 1);
        }
        
        private void UpdateText()
        {
            if(!_isCoding) return;
            if(!_os.Tasks.IsEmpty() && _os.Tasks.First() is Building) return;
            if (_code.IsEmpty()) _code = GetNewCodeExampleByList(_sCode.ProgramingLanguage);
            var currentIndex = _sCode.TypingSpeed;
            while (currentIndex > 0)
            {
                _text.text += _code.First();
                _code.RemoveAt(0);
                if (_code.IsEmpty()) _code =  GetNewCodeExampleByList(_sCode.ProgramingLanguage);
                if (_code.First() != ' ') currentIndex--;
                if (_code.First() != '\n') currentIndex--;
                _sCode.IncreaseSymbolsByOne();
                Scrolling(0, 0);
            }
        }

        private void Scrolling(int x, int y)
        {
            _scrollRect.normalizedPosition = new Vector2(x, y);
        }

        private List<char> GetNewCodeExampleByList(ProgramingLanguages languages)
        {
            return GetNewCodeExample(languages)
                .ToCharArray()
                .ToList();
        }
        
        private string GetNewCodeExample(ProgramingLanguages languages)
        {
            return _sCode.LanguagesAssets.First(language => language.ProgramingLanguages == languages).Assets[Random.Range(0, _sCode.LanguagesAssets.Count - 1)].ToString();
        }
    }
}