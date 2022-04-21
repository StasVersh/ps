using System.Collections.Generic;
using System.IO;
using ProjectAssets.Pages.Notepad.Scripts.Models;
using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TypingController : MonoBehaviour
{
    [SerializeField] private List<string> _codeList;

    private TMP_Text _textForWriting;
    private ScrollRect _scrollRect;
    private Player _player;
    private string _codeBody;
    private int _index;

    [Inject]
    private void Construct(Code code, Player player)
    {
        _textForWriting = code.Text;
        _textForWriting.text = File.ReadAllText(_codeList[Random.Range(0, _codeList.Count - 1)]);
        _codeBody = code.Text.text;
        _player = player;
        _scrollRect = code.ScrollRect;
        _textForWriting.text = "";
        _player.Step = 1;
    }

    private void Update()
    {
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2))
        {
            if (_index < _codeBody.Length)
            {
                int count = 0;
                while (count < _player.Step)
                {
                    _textForWriting.text += _codeBody[_index];
                    _scrollRect.normalizedPosition = new Vector2(0, 0);
                    var rect = _scrollRect.content.rect;
                    _scrollRect.content.rect.Set(rect.x, rect.y, _textForWriting.maxWidth, _textForWriting.maxHeight);
                    _player.Increment();
                    _index++;
                    if (_codeBody[_index] != ' ' && _codeBody[_index] != '\n' && _codeBody[_index] != '\r') count++;
                }   
            }
            else
            {
                _codeBody += File.ReadAllText(_codeList[Random.Range(0, _codeList.Count - 1)]);;
            }
        }
    }
}
