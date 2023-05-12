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
            if (instance == null)
            {
                Debug.LogError("GameManager is null!");
            }
            return instance;
        } 
        private set { instance = value; }
    }
    [Header("Scene Management")]
    [SerializeField] private int TotalSceneAmount;
    private int currentScene = 0;
    // Should these be GameObject arrays?
    public GameObject PresentSetting;
    public GameObject FutureSetting;
    [Space]
    [Header("Player")]
    [SerializeField] private GameObject PlayerWithoutGun;
    [SerializeField] private GameObject PlayerWithGun;

    // Maybe set player spawn points
    [SerializeField] private List<Transform> PlayerSpawnPoints;
    public int PlayerAmmo { get; set; } = 0;

    private void Awake()
    {
        Instance = this;
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

    public void NextLevel()
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

        SwitchToPresentSetting();

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
        SwitchToPresentSetting();

    }

    public void SwitchSetting()
    {
        //Should we add scene switch effect?
        if(PresentSetting.activeSelf)
        {
            FutureSetting.SetActive(true);
            PresentSetting.SetActive(false);
        }
        else
        {
            FutureSetting.SetActive(false);
            PresentSetting.SetActive(true);
        }
    }

    private void SwitchToPresentSetting()
    {
        PresentSetting.SetActive(true);
        FutureSetting.SetActive(false);
    }


    void Update()
    {
        
    }
}
