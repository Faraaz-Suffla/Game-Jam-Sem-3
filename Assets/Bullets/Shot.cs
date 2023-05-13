using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private string tagName = "Enemy";
    [SerializeField] private GameObject impactEffect;
    void Start()
    {
        rigidbody.velocity = transform.right * speed;
        Invoke(nameof(DestroyShot), 1);
    }

    private void DestroyShot()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag(tagName))
        {
            //get enemy component
            // destroy that enemy
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
