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
    [SerializeField] private int TotalSceneAmount;
    private int currentScene = 0;
    [SerializeField] private int StartLevelSceneIndex;
    [SerializeField] private int EndLevelSceneIndex;
    // Should these be GameObject arrays?
    public GameObject PresentSetting;
    public GameObject FutureSetting;
    public GameObject CurrentSetting; // for shots to be in the right setting
    [Space]
    [Header("Player")]
    [SerializeField] private GameObject PlayerWithoutGun;
    [SerializeField] private GameObject PlayerWithGun;

    // Maybe set player spawn points
    //[SerializeField] private List<Transform> PlayerSpawnPoints;
    [SerializeField] private int StartingPlayerAmmo;
    public int PlayerAmmo { get; set; }
    private int playerAmmoAtLevelStart;
    public bool PlayerOnMovingPlatform { get; set; } = false;
    [Space]
    [Header("Other")]
    public bool isGamePaused = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            
            //Destroy(gameObject);
            //Debug.Log("GameManager object has been destroyed!");
        }

        StartFirstLevel();
    }

    public void PlayerPicksUpGun()
    {
        Transform playerPosition = PlayerWithoutGun.transform;
        Destroy(PlayerWithoutGun);
        Instantiate(PlayerWithGun, playerPosition);
    }

    public void PlayerDie()
    {

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

        if (isCurrentSceneALevel())
        {
            StartLevel();
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
        PlayerWithGun = GameObject.FindGameObjectWithTag("Player");
        PresentSetting = GameObject.FindGameObjectWithTag("PresentSetting");
        FutureSetting = GameObject.FindGameObjectWithTag("FutureSetting");
        SwitchToPresentSetting();
        playerAmmoAtLevelStart = PlayerAmmo;
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

    public void SwitchSetting()
    {
        //Should we add scene switch effect?
        if(PlayerOnMovingPlatform)
        {
            PlayerWithGun.transform.SetParent(null, true);
        }
        if(PresentSetting.activeSelf)
        {
            FutureSetting.SetActive(true);
            PresentSetting.SetActive(false);
            CurrentSetting = FutureSetting;
        }
        else
        {
            FutureSetting.SetActive(false);
            PresentSetting.SetActive(true);
            CurrentSetting = PresentSetting;
        }
    }
    private void SwitchToPresentSetting()
    {
        PresentSetting.SetActive(true);
        FutureSetting.SetActive(false);
        CurrentSetting = PresentSetting;
    }

    public void PauseToggle() // To pause or unpause the game
    {
        if(isGamePaused)
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
        isGamePaused = true;
    }
    public void UnpauseGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void QuitToMenu()
    {
        UnpauseGame();
    }
    public void OnApplicationPause(bool pause)
    {
        
    }



    void Update()
    {
        
    }
}
