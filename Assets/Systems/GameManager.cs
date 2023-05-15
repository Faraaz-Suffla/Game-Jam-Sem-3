using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            //if (instance == null)
            //{
            //    Debug.LogError("GameManager is null!");
            //}
            return instance;
        }
        private set { instance = value; }
    }

    [Header("Scene Management")]
    private int TotalSceneAmount;
    public int currentScene = 0;
    [SerializeField] private int StartLevelSceneIndex;
    [SerializeField] private int EndLevelSceneIndex;
    // Should these be GameObject arrays?
    [Space]
    [Header("Player")]

    // Maybe set player spawn points
    //[SerializeField] private List<Transform> PlayerSpawnPoints;
    [SerializeField] private int StartingPlayerAmmo;
    public int PlayerAmmo { get; set; }
    private int playerAmmoAtLevelStart;
    public bool PlayerOnMovingPlatform { get; set; } = false;
    //[Space]
    //[Header("Other")]
    public bool IsGamePaused { get; set; } = false;
    public bool ControlsDisabled { get; set; } = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            //Debug.Log("GameManager object has been destroyed!");
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        TotalSceneAmount = SceneManager.sceneCount;


        StartScene();
    }


    

    public void PlayerDie()
    {
        RestartLevel();
    }
    
    

    public void NextScene()
    {
        if (currentScene != TotalSceneAmount)
        {
            currentScene++;
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            currentScene = 0;
            SceneManager.LoadScene(currentScene);
            return;
        }



    }
    private void StartFirstLevel()
    {
        // player turns into player without gun if restart first level
        PlayerAmmo = StartingPlayerAmmo;
        StartLevel();
    }

    private void StartLevel()
    {
        
        //ScenesManager.Instance.SwitchToPresentSetting();
        playerAmmoAtLevelStart = PlayerAmmo;
        ControlsDisabled = false;
    }

    private bool isCurrentSceneALevel()
    {
        return currentScene >= StartLevelSceneIndex && currentScene <= EndLevelSceneIndex;
    }

    public void RestartLevel()
    {
        if (isCurrentSceneALevel())
        {
            SceneManager.LoadScene(currentScene);
            PlayerAmmo = playerAmmoAtLevelStart;

        }
    }

    public void SwitchSetting()
    {
        ScenesManager.Instance.SwitchSetting();
    }
    

    public void PauseToggle() // To pause or unpause the game
    {
        if (IsGamePaused)
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        IsGamePaused = true;
        ControlsDisabled = true;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        IsGamePaused = false;
        ControlsDisabled = false;
    }

    public void QuitToMenu()
    {
        UnpauseGame();
    }

    private void StartScene()
    {
        if (isCurrentSceneALevel())
        {
            if (currentScene == StartLevelSceneIndex)
            {
                StartFirstLevel();
            }
            else
            {
                StartLevel();
            }
        }
    }

    
}
