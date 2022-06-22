using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Interfacese;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Scriptable
{
    [CreateAssetMenu(fileName = "ListTile", menuName = "ListView", order = 1)]
    public class ListTile : ScriptableObject, ITile
    {
        [Header("Text")]
        [SerializeField] public string Header;
        [TextArea(5,10)]
        [SerializeField] public string Description;
        [Header("Coast")]
        [SerializeField] public int BaceCoast;
        [SerializeField] public float CoastScaling;
        [Header("Action")]
        [SerializeField] public StorePoints Action;
        [HideInInspector] public bool IsEnable;
        [HideInInspector] public int Level;
        public UnityEvent OnBuying { get; set; }
        
        public long GetCoast()
        {
            long coast = BaceCoast;
            for (var i = 0; i < Level - 1; i++)
            {
                coast = (long) (coast * CoastScaling);
            }
            return coast;
        }

        public bool Buy(OperationSystem operationSystem)
        {
            return operationSystem.WriteOffScd(GetCoast());
        }
    }
}
