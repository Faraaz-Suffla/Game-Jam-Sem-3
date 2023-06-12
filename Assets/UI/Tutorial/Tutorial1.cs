using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1 : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        sprite.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        sprite.enabled = false;
    }
}
