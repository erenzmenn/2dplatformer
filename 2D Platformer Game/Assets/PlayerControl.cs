using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anm;
    private float dX;
    private SpriteRenderer sprite;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 12f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);     
        }
        UpdateAnimationUpdate();
        
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state; 

        if (dX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anm.SetInteger("state", (int)state);
    }
}
 