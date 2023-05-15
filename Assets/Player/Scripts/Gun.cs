using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    public Transform firePoint;
    public GameObject shotPrefab;

    void Update()
    {
        //if (GameManager.Instance.ControlsDisabled == false)
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
        //Invoke(nameof(GameManager.Instance.SwitchSetting), 1f); //idk why this doesn't work
        StartCoroutine(SettingSwitchDelay());
        Instantiate(shotPrefab, firePoint.position, firePoint.rotation, GameManager.Instance.CurrentSetting.transform);
    }

    private IEnumerator SettingSwitchDelay()
    {
        yield return new WaitForSeconds(0.2f);
        GameManager.Instance.SwitchSetting();
    }
}
