using ProjectAssets.Resources.Scripts.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "ListTile", menuName = "ListView", order = 1)]
    public class ListTile : ScriptableObject
    {
        [SerializeField] public int Level;
        [Header("Text")]
        [SerializeField] public string Header;
        [TextArea(5,10)]
        [SerializeField] public string Description;
        [Header("Coast")]
        [SerializeField] public int Coast;
        [SerializeField] public float CoastScaling;
        [Header("Action")]
        [SerializeField] public StorePoints Action;
        [HideInInspector]
        public bool IsEnable;
        
        public UnityEvent Bay { get; set; }
    }
}
