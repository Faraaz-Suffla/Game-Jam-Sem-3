using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Transform firePoint;
    public GameObject shotPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.isGamePaused == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if(GameManager.Instance.PlayerAmmo > 0)
                {
                    GameManager.Instance.PlayerAmmo--;
                    Attack();
                }
            }
        }
    }

    public override void Attack()
    {
        base.Attack();
        Instantiate(shotPrefab, firePoint.position, firePoint.rotation);
    }
}
