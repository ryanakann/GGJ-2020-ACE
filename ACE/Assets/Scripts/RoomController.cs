using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : Entity
{
    float gravity = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Physics2D.gravity = Vector2.up * gravity;
    }

    void ResetGravity()
    {
        print("ResetGravity");
        gravity = -9.8f;
    }

    void InvertGravity()
    {
        print("InvertGravity");
        gravity = 9.8f;
    }
}
