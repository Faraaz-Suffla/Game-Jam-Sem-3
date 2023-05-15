using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : Collectibles
{
    public override void Collect()
    {
        ScenesManager.Instance.PlayerPicksUpGun();
        base.Collect();
    }
}
