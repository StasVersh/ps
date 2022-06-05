using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class StoreListViewController : MonoBehaviour
    {
        [FormerlySerializedAs("_ListTilePrefab")] [SerializeField] private GameObject _listTilePrefab;
        public readonly List<ListTile> ListTiles = new List<ListTile>();

        public void UpdateList()
        {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }

            foreach (ListTile listTile in ListTiles)
            {
                var tileObject = Instantiate(_listTilePrefab, transform.position, Quaternion.identity, transform);
                var listTileController = tileObject.GetComponent<ListTileController>();
                listTileController.Level.text = $"Lvl. {listTile.Level}";
                listTileController.Header.text = listTile.Header;
                listTileController.Description.text = listTile.Description;
                listTileController.Coast.text = $"{listTile.Coast} SCD";
                listTileController.CoastButton.interactable = listTile.IsEnable;
                listTileController.ListTileButton.interactable = listTile.IsEnable;
            }
        }
    }
}