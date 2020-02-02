using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity {
    public float speed = 2f;
    public float jumpSpeed = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float moveX;

    public bool grounded;

    Rigidbody2D rb;
    Collider2D col;
    SpriteRenderer sr;
    Animator anim;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update () {
        base.Update();
        rb.velocity = new Vector2(0, rb.velocity.y);
        moveX = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveX) < 0.1f) moveX = 0f;
        anim.SetFloat("moveX", moveX);

        if (moveX > 0) {
            holdRightEvent.Invoke();
        } else if (moveX < 0) {
            holdLeftEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("Jump");
            pressSpaceEvent.Invoke();
        }
    }

    public void MoveLeft () {
        print("Moving left");
        sr.flipX = true;
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void MoveRight () {
        print("Moving right");
        sr.flipX = false;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Jump () {
        print("Jumping");
        var hit = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0,
            Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        if (hit.collider != null) {
            //print("on ground");
            rb.velocity = Vector2.up * jumpSpeed;
        }
        //else print("off ground");
    }
}
