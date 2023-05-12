using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : Collectibles
{
    public override void Collect()
    {
        GameManager.Instance.PlayerPicksUpGun();
        base.Collect();
    }
}
