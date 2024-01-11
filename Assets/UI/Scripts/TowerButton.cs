using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TowerDefense
{
    [RequireComponent(typeof(Button))]
    public class TowerButton : MonoBehaviour
    {
        Button button;
        Player player;
        DisplayTowerInfo displayTowerInfo;

        public Tower_SO towerType;
        
        
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
            displayTowerInfo = FindObjectOfType<DisplayTowerInfo>(true);
        }

        private void OnClick()
        {
            if (displayTowerInfo) displayTowerInfo.Show(towerType);
            Player.towerType = towerType;
        }
    }

}
