using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer playerSprite;
    private BoxCollider2D collider;
    [SerializeField] private LayerMask groundLayer;
    [Space]
    private float xMovement;
    private float yMovement;
    [SerializeField] private float xSpeed = 5;
    [SerializeField] private float jumpSpeed = 8f;

    private enum AnimationStates
    {
        Idle,
        Run,
        Jump,
        Fall,
    }
    private AnimationStates state;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        xMovement = Input.GetAxisRaw("Horizontal") * xSpeed;
        yMovement = rigidBody.velocity.y;
        
        if (Input.GetButtonDown("Jump") && isGroundedCheck())
        {
            yMovement = jumpSpeed;
        }
        rigidBody.velocity = new Vector2(xMovement, yMovement);

    }
    private void FixedUpdate()
    {
        SetAnimatorState();
    }

    private void SetAnimatorState()
    {
        if (xMovement > 0)
        {
            playerSprite.flipX = false;
        }
        else if (xMovement < 0)
        {
            playerSprite.flipX = true;
        }

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
            if (rigidBody.velocity.y > 0)
            {
                state = AnimationStates.Jump;
            }
            else if (rigidBody.velocity.y < 0)
            {
                state = AnimationStates.Fall;
            }
        }

        animator.SetInteger("State", (int)state);
    }

    private bool isGroundedCheck()
    {
        //Debug.DrawRay(transform.position, new Vector2());
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.15f, groundLayer);
    }
}
