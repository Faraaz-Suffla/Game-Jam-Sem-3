using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Collectibles
{
    public override void Collect()
    {
        GameManager.Instance.PlayerAmmo++; // give player 1 bullet
        base.Collect();
    }
}
