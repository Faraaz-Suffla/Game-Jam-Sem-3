using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("OpenDoor");
        }
    }

    private void GoToNextLevel() // Called in animation event
    {
        GameManager.Instance.PlayerLeaveLevel(1);
        Invoke(nameof(CloseDoor), 1.1f);
    }
    private void CloseDoor()
    {
        animator.SetTrigger("CloseDoor");
    }

    private void NextLevel() // Called in animation event
    {
        GameManager.Instance.NextScene();
    }
}
