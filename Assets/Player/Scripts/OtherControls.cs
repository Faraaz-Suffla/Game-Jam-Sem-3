using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherControls : MonoBehaviour
{
    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.PauseToggle();
        }

        if (GameManager.Instance.isGamePaused == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.RestartLevel();
            }

        }
    }
}
