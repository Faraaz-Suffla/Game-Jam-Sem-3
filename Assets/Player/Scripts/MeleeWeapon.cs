using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform attackOrigin;
    [SerializeField] private float attackRadius;
    [SerializeField] private LayerMask targetLayer;
    private RaycastHit2D hit;
    void Update()
    {
        //if(GameManager.Instance.isGamePaused == false)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Attack();
            }

        }
    }
    public override void Attack()
    {
        animator.SetTrigger("Melee");
        base.Attack();
    }

    private void Melee() // called in melee animation
    {
        hit = Physics2D.CircleCast(attackOrigin.position, attackRadius, Vector2.right, attackRadius + 1, targetLayer);
        if (hit.collider.CompareTag(TargetTag))
        {

        }
    }
}
