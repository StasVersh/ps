using ProjectAssets.Pages.Notepad.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TypingController : MonoBehaviour
{
    private TMP_Text _textForWriting;
    private ScrollRect _scrollRect;
    private string _codeBody;
    private int _index;

    [Inject]
    private void Construct(Code code)
    {
        _textForWriting = code.Text;
        _codeBody = code.Text.text;
        _scrollRect = code.ScrollRect;
        _textForWriting.text = "";
    }

    private void Update()
    {
        if (Input.anyKeyDown && _index < _codeBody.Length)
        {
            _textForWriting.text += _codeBody[_index];
            _scrollRect.normalizedPosition = new Vector2(0, 0);
            var rect = _scrollRect.content.rect;
            _scrollRect.content.rect.Set(rect.x, rect.y, _textForWriting.maxWidth, _textForWriting.maxHeight);
            _index++;
        }
    }
}
