using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherControls : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Awake()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.PauseToggle();
        }

        if (GameManager.Instance.ControlsDisabled == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.RestartLevel();
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstacle":
            case "EnemyAttack":
                AboutToDie();
                break;
        }
        
    }

    private void AboutToDie()
    {
        GameManager.Instance.ControlsDisabled = true;
        animator.SetTrigger("TakeDamage");
    }

    private void Die() // Called in animator
    {
        GameManager.Instance.PlayerDie();
    }
}
