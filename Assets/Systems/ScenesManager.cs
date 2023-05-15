using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance { get; private set; }

    [Header("Scene Management")]
    // Should these be GameObject arrays?
    public GameObject PresentSetting;
    public GameObject FutureSetting;
    public GameObject CurrentSetting; // for shots to be in the right setting
    [Space]
    [Header("Player")]
    [SerializeField] private GameObject PlayerWithGun;
    [SerializeField] private GameObject PlayerWithoutGun;
    [SerializeField] private int thisSceneIndex;


    public void PlayerPicksUpGun()
    {
        //Transform playerPosition = PlayerWithoutGun.transform;
        //Destroy(PlayerWithoutGun);
        //Instantiate(PlayerWithGun, playerPosition);
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //if (GameManager.Instance.currentScene != thisSceneIndex)
        //{
        //    Destroy(gameObject);
        //}
    }
    private SpriteRenderer playerSprite;
    public void PlayerLeaveLevel(float leaveDuration)
    {
        GameManager.Instance.ControlsDisabled = true;
        playerSprite = PlayerWithGun.GetComponent<SpriteRenderer>();
        StartCoroutine(MakePlayerTransparent(leaveDuration));
    }
    private IEnumerator MakePlayerTransparent(float duration) // Code from this video about Lerp: https://www.youtube.com/watch?v=RNccTrsgO9g
    {
        float timeElapsed = duration;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            playerSprite.color = new Color(1f, 1f, 1f, Mathf.Lerp(0, 1, t));
            timeElapsed -= Time.deltaTime;

            yield return null;
        }
        playerSprite.color = new Color(1f, 1f, 1f, 0f);
    }
    public bool PlayerOnMovingPlatform { get; set; } = false;

    public void SwitchToPresentSetting()
    {
        PresentSetting.SetActive(true);
        FutureSetting.SetActive(false);
        CurrentSetting = PresentSetting;
    }

    public void SwitchSetting()
    {
        //Should we add scene switch effect?
        if (PlayerOnMovingPlatform)
        {
            PlayerWithGun.transform.SetParent(null, true);
        }
        if (PresentSetting.activeSelf)
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
}
