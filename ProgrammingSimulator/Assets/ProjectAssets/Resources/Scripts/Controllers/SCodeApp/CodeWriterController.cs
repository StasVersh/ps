using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
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
        }

        private void Start()
        {
            _text.text = _sCode.BinaryCode[Random.Range(0, _sCode.BinaryCode.Count - 1)].ToString();
            _scrollRect.normalizedPosition = new Vector2(0, 0);
        }

        private void CurrentWindowChanging(App state)
        {
            _isCoding = state is App.SCode;
        }


        private void UpdateText()
        {
            if(!_isCoding) return;
            if(!_os.Tasks.IsEmpty() && _os.Tasks.First() is Building) return;
            if (_code.IsEmpty()) _code = GetNewCodeExample();
            var currentIndex = _sCode.TypingSpeed;
            while (currentIndex > 0)
            {
                _text.text += _code.First();
                _code.RemoveAt(0);
                if (_code.IsEmpty()) _code =  GetNewCodeExample();
                if (_code.First() != ' ' && _code.First() != '\n') currentIndex--;
                _sCode.IncreaseSymbolsByOne();
                _scrollRect.normalizedPosition = new Vector2(0, 0);
            }
        }

        private List<char> GetNewCodeExample()
        {
            return _sCode.BinaryCode[Random.Range(0, _sCode.BinaryCode.Count - 1)]
                .ToString()
                .ToCharArray()
                .ToList();
        }
    }
}