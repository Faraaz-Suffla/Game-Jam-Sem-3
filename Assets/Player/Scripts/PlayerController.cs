using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform; // follow platform
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null, true); // stop following platform
        }
    }


    private void Die()
    {
        animator.SetTrigger("DieTrigger");
        rigidbody.bodyType = RigidbodyType2D.Static; // freeze in position
    }

    private void RestartGame() // called on die animation event
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
