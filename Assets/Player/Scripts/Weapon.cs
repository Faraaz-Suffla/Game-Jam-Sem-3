using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public string TargetTag { get; set; }
    //public GameObject TargetCharacter { get; set; }

    void Update()
    {
        
    }

    public virtual void Attack()
    {

    }
}
