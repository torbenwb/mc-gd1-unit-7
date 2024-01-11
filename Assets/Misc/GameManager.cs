using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using TowerDefense;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static int currentLevel { get; private set; } = 0;
    public GameSettings gameSettings;
    public static GameSettings _gameSettings;
    public static SpawnerBehaviour_SO levelSpawnerBehavior => _gameSettings.levels[currentLevel];
    public static bool menuOpen = false;
    public static GameMenu gameMenu;
    private void Awake()
    {
        if (instance) Destroy(gameObject);
        else {
            instance = this;
            DontDestroyOnLoad(this);
            if (!_gameSettings) _gameSettings = gameSettings;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentLevel != 0)
            {
                currentLevel = 0;
                MainMenu();
            }
        }
    }

    static GameManager Instance{
        get{
            if (!instance){
                GameObject n = new GameObject("Game Manager");
                return n.AddComponent<GameManager>();
            }
            return instance;
        }
    }

    public static void Quit()
    {
        Application.Quit();
    }

    public static void GameOver(){
        OpenMenu("Defeat");
    }

    public static void MainMenu()
    {
        currentLevel = 0;
        SceneManager.LoadScene(0);
        
    }

    public static void OpenMenu(string menuMessage = "Menu")
    {
        gameMenu.gameObject.SetActive(true);
        gameMenu.SetMessage(menuMessage);
        menuOpen = true;
        Time.timeScale = 0f;
    }

    public static void CloseMenu()
    {
        gameMenu.gameObject.SetActive(false);
        menuOpen = false;
        Time.timeScale = 1f;
    }

    public static void ToggleMenu()
    {
        if (menuOpen) CloseMenu();
        else OpenMenu();
    }

    public bool LoadLevel(int level)
    {
        //Debug.Log($"Load Level {level}");
        SceneManager.LoadScene($"Level{level}");
        return true;
    }

    public static void NextLevel()
    {
        currentLevel++;
        if (currentLevel >= _gameSettings.maxLevel) currentLevel = 1;
        

        instance.StartLevelTransition(currentLevel);
    }

    public static void Restart()
    {
        if (menuOpen)
        {
            CloseMenu();
        }
        currentLevel = 1;
        instance.StartLevelTransition(currentLevel);
    }

    public void StartLevelTransition(int nextLevel)
    {
        GetComponentInChildren<LevelTransition>().StartTransition(nextLevel, LoadLevel);
    }
}
