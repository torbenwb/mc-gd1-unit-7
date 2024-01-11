using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefense
{

    public class Player : MonoBehaviour
    {
        private static Tower_SO _towerType;
        public static Tower_SO towerType;
        
        
        public static int gold;
        public static int health;

        Grid grid;
        Cursor cursor;
        UICursorCapture cursorCapture;
        DisplayTowerInfo displayTowerInfo;

        private void Awake()
        {
            grid = FindObjectOfType<Grid>();
            cursorCapture = FindObjectOfType<UICursorCapture>();
            displayTowerInfo = FindObjectOfType<DisplayTowerInfo>(true);
            cursor = GetComponentInChildren<Cursor>();

            // Event bus
            EventBus.GetEvent("EnemyDead").AddListener(OnEnemyDead);  
        }

        private void Start()
        {
            if (GameManager.currentLevel == 1) gold = GameManager._gameSettings.startingGold;
            if (GameManager.currentLevel == 1) health = GameManager._gameSettings.startingHealth;
            ValueDisplay.OnValueChanged.Invoke("Gold", gold);
            ValueDisplay.OnValueChanged.Invoke("Health", health);
        }

        public void GameOver(){
            //SceneManager.LoadScene("GameOver");
            GameManager.GameOver();
        }

        private void Update()
        {
            if (health <= 0) return;
            if (!towerType) return;

            if (Input.touchCount > 0)
            {
                //if (cursorCapture.cursorOverUI) return;

                if (Cursor.TryGetTargetTouchTile(out var tile))
                {
                    TryPlaceTower(tile);
                }

                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                towerType = null;
                displayTowerInfo.Hide();
                return;
            }

            

            if (Input.GetMouseButtonDown(0) && !cursorCapture.cursorOverUI)
            {
                if (Cursor.TryGetTargetTile(out var targetTile))
                {
                    TryPlaceTower(targetTile);
                }
                
            }
            
        }

        public bool TryPlaceTower(Vector3Int tileCoordinates)
        {
            int cost = towerType.cost;
            if (gold < cost) return false;
            if (Grid.Occupied(tileCoordinates)) return false;

            GameObject newTower = Instantiate(towerType.towerPrefab, tileCoordinates, Quaternion.identity);
            Grid.Add(tileCoordinates, newTower);
            gold-=cost;
            ValueDisplay.OnValueChanged.Invoke("Gold",gold);
            return true;
        }

        // Added later
        public void Addgold(int amount){
            gold+=amount;
            ValueDisplay.OnValueChanged.Invoke("Gold",gold);
        }

        public static void ChangeGold(int amount)
        {
            gold += amount;
            ValueDisplay.OnValueChanged.Invoke("Gold", gold);
        }

        public static void ChangeHealth(int amount)
        {
            health += amount;
            if (amount < 0)
            {
                CameraManager.CameraShake();
            }
            ValueDisplay.OnValueChanged.Invoke("Health", health);
            if (health <= 0)
            {
                GameManager.GameOver();
            }
        }

        public void OnEnemyDead(){
            //Debug.Log("Player heard enemy dead");
            Addgold(1);
        }
    }
}

