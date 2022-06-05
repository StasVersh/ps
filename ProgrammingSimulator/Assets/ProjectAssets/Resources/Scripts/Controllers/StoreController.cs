using System;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class StoreController : MonoBehaviour
    {
        private void Start()
        {
            var listView = GetComponent<StoreListViewController>();
            listView.ListTiles.Add(new ListTile(1,"IT courses", "These courses will increase your skill level, which will allow you to write more code at a time.", 250, true));
            listView.ListTiles.Add(new ListTile(4,"Monitor SAVA PST-48738", "Tired of living in a square? buy a new monitor and your world will change forever", 46000, false));
            listView.UpdateList();
        }
    }
}