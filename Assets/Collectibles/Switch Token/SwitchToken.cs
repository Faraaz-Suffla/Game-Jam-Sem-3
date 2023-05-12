using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToken : Collectibles
{
    public override void Collect()
    {
        GameManager.Instance.SwitchSetting();
        base.Collect();
    }
}
