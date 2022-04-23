using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Michsky.UI.ModernUIPack;
using ProjectAssets.Pages.SDos.SDCode.Scripts.Models;
using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace ProjectAssets.Pages.SDos.SDCode.Scripts.Controllers
{
    public class SDCodeController : MonoBehaviour
    {
        private SDCodeModel _sdCodeModel;
        private InputManager _inputManager;
        private Player _player;
        
        private TMP_Text _textForWriting;
        private TMP_Text _symbolsCounterText;
        private ScrollRect _scrollRect;
        private Button _buildButton;
        private ProgressBar _progressBar;
        private ModalWindowManager _modalWindow;
        
        private int _index;
        private int _symbols;
        private string _codeBody;
        private bool _isCompelating;
        private List<string> _paths = new List<string>()
        {
            @"C:\Users\micro\Documents\GitHub\ps\ProgrammingSimulator\Assets\ProjectAssets\Resources\Code\10\01.txt",
            @"C:\Users\micro\Documents\GitHub\ps\ProgrammingSimulator\Assets\ProjectAssets\Resources\Code\10\02.txt",
        };

        [Inject]
        private void Construct(SDCodeModel sdCodeModel, InputManager inputManager, Player player)
        {
            _sdCodeModel = sdCodeModel;
            _inputManager = inputManager;
            _player = player;
            UIBinding();
            AddListeners();
        }
        
        private void Start()
        {
            ResetUI();
        }

        private void UIBinding()
        {
            _textForWriting = _sdCodeModel.Code;
            _scrollRect = _sdCodeModel.Scrolling;
            _symbolsCounterText = _sdCodeModel.Symbols;
            _buildButton = _sdCodeModel.BuildButton;
            _progressBar = _sdCodeModel.ProgressBar;
            _modalWindow = _sdCodeModel.DoneCompilationWindow;
        }

        private void AddListeners()
        {
            _progressBar.onValueChanged.AddListener(Progressing);
            _buildButton.onClick.AddListener(Build);
            _inputManager.OnClick.AddListener(OnClick);
            _inputManager.OnBuild.AddListener(Build);
            _inputManager.OnEnter.AddListener(Enter);
        }

        private void Enter()
        {
            if(_isCompelating) return;
            if (_modalWindow.isOn) _modalWindow.CloseWindow();
        }

        private void OnClick()
        {
            if(_isCompelating) return;
            _codeBody ??= File.ReadAllText(_paths[Random.Range(0, _paths.Count - 1)]);
            var count = 0;
            while (count < _player.Step)
            {
                if (_index == _codeBody.Length - 1) _codeBody += $"\n{File.ReadAllText(_paths[Random.Range(0, _paths.Count - 1)])}";
                _textForWriting.text += _codeBody[_index];
                _scrollRect.normalizedPosition = new Vector2(0, 0);
                var rect = _scrollRect.content.rect;
                _scrollRect.content.rect.Set(rect.x, rect.y, _textForWriting.maxWidth, _textForWriting.maxHeight);
                _symbols++;
                _index++;
                if (_codeBody[_index] != ' ' && _codeBody[_index] != '\n' && _codeBody[_index] != '\r') count++;
            }
            _symbolsCounterText.text = _symbols.ToString();
        }

        private void Build()
        {
            if (_progressBar.currentPercent == 0f)
            {
                _progressBar.speed = 8;
                _progressBar.isOn = true;
            }
        }
        
        public void Progressing(float value)
        {
            _isCompelating = value is > 0 and <= 100;
            if (!(value >= 100f)) return;
            _modalWindow.OpenWindow();
            _player.Increment(_symbols);
            ResetUI();
        }

        private void ResetUI()
        {
            _symbols = 0;
            _symbolsCounterText.text = _symbols.ToString();
            _progressBar.currentPercent = 0f;
            _progressBar.isOn = false;
            _progressBar.restart = false;
            _progressBar.UpdateUI();
        }
    }
}