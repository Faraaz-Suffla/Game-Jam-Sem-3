using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
        }
    }
    public override void Attack()
    {
        
        animator.SetTrigger("Melee");
        base.Attack();
    }
}
