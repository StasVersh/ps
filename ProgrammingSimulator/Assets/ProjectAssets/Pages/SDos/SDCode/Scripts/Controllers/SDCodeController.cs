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
        
        private int _index;
        private int _symbols;
        private string _codeBody;
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
            _textForWriting = sdCodeModel.Code;
            _scrollRect = sdCodeModel.Scrolling;
            _symbolsCounterText = sdCodeModel.Symbols;
            _buildButton = sdCodeModel.BuildButton;
            _progressBar = sdCodeModel.ProgressBar;
            
            _progressBar.onValueChanged.AddListener(Progressing);
            _buildButton.onClick.AddListener(Build);
            _inputManager.OnClick.AddListener(OnClick);
            _inputManager.OnBuild.AddListener(Build);
        }

        private void Start()
        {
            _textForWriting.text = String.Empty;
            _codeBody += File.ReadAllText(_paths.First());
            _symbolsCounterText.text = 0.ToString();
            _player.Step = 1;
            _progressBar.currentPercent = 0f;
            _progressBar.isOn = false;
            _progressBar.restart = false;
        }

        private void OnClick()
        {
            if(_progressBar.currentPercent == 0f)
                if (_index < _codeBody.Length)
                {
                    int count = 0;
                    while (count < _player.Step)
                    {
                        _textForWriting.text += _codeBody[_index];
                        _scrollRect.normalizedPosition = new Vector2(0, 0);
                        var rect = _scrollRect.content.rect;
                        _scrollRect.content.rect.Set(rect.x, rect.y, _textForWriting.maxWidth, _textForWriting.maxHeight);
                        _symbols++;
                        _index++;
                        if (_codeBody[_index] != ' ' && _codeBody[_index] != '\n' && _codeBody[_index] != '\r') count++;
                    }   
                }
                else
                {
                    _codeBody += File.ReadAllText(_paths[Random.Range(0, _paths.Count - 1)]);;
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
            if (value >= 100f)
            {
                _player.Increment(_symbols);
                _symbols = 0;
                _symbolsCounterText.text = _symbols.ToString();
                _progressBar.currentPercent = 0f;
                _progressBar.isOn = false;
            }
        }
    }
}