using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

public class CoinsViewer : MonoBehaviour
{
    private Player _player;
    private TMP_Text _text;
    
    [Inject]
    private void Construct(Player player)
    {
        _player = player;
        _player.OnValueChanged.AddListener(OnValueChanged);
        _text = gameObject.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        OnValueChanged();
    }

    private void OnValueChanged()
    {
        _text.text = _player.SCD.ToString();
    }
}
