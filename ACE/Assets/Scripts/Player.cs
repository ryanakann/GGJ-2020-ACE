using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity {
    public float speed = 2f;
    public float jumpSpeed = 10f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody2D rb;
    Collider2D col;

    protected override void Awake () {
        base.Awake();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    protected override void Update () {
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") > 0) {
            print("Press right");
            holdRightEvent.Invoke();
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            print("Press left");
            holdLeftEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            print("Press space");
            pressSpaceEvent.Invoke();
        }
    }

    public void MoveLeft () {
        print("Moving left");
        GetComponent<SpriteRenderer>().flipX = true;
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }

    public void MoveRight () {
        print("Moving right");
        GetComponent<SpriteRenderer>().flipX = false;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Jump () {
        print("Jumping");
        if (Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0,
            Vector2.down, 0.1f, LayerMask.GetMask("Ground")).collider != null)
        {
            print("on ground");
            rb.velocity = Vector2.up * jumpSpeed;
        }
        else print("off ground");
    }
}
