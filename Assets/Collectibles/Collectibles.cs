using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectibles : MonoBehaviour
{
    // Can be set in inspector for different collectibles
    public GameObject CollectEffect;
    public AudioClip CollectSound;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }
    public virtual void Collect()
    {
        Instantiate(CollectEffect, transform.position, transform.rotation);
    }
    public void DestroyObject() // Called on collect animation event
    {
        Destroy(gameObject);
    }
}

