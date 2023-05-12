using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    private Animator animator;
    public CharacterController2D controller;
    [Space]
    private float xMovement;
    private float yMovement;
    [SerializeField] private float xSpeed = 40;
    private bool isGrounded;

    [SerializeField] private CapsuleCollider2D collider;
    [SerializeField] private LayerMask groundLayer;

    private enum AnimationStates
    {
        Idle,
        Run,
        Jump,
        Fall,
    }
    private AnimationStates state;

    bool jump = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        xMovement = Input.GetAxisRaw("Horizontal") * xSpeed;
        yMovement = rigidBody.velocity.y;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            isGrounded = false;
        }

        
        else if (Input.GetButtonDown("Fire2"))
        {
            Melee();
        }
    }
     private void Shoot()
    {
        
    }

    private void Melee()
    {
        animator.SetTrigger("Melee");
    }

    private void FixedUpdate()
    {
        controller.Move(xMovement * Time.fixedDeltaTime, jump);
        jump = false;
        SetAnimatorState();
    }

    private void SetAnimatorState()
    {
        if (isGroundedCheck())
        {
            if(Mathf.Abs(xMovement) > 0)
            {
                state = AnimationStates.Run;
            }
            else
            {
                state = AnimationStates.Idle;
            }
        }
        else
        {
            if (yMovement > 0)
            {
                state = AnimationStates.Jump;
            }
            else if (yMovement < 0)
            {
                state = AnimationStates.Fall;
            }
        }

        animator.SetInteger("State", (int)state);
    }

    public void OnLanding()
    {
        isGrounded = true;
    }

    private bool isGroundedCheck()
    {
        //Debug.DrawRay(transform.position, new Vector2());
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.15f, groundLayer);
    }
}
