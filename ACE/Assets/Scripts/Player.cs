using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : Entity {
    protected override void Awake () {
        base.Awake();
    }

    protected override void Update () {
        base.Update();

        if (Input.GetAxisRaw("Horizontal") > 0) {
            print("Press right");
            //print(holdRightEvent.ToString());
            holdRightEvent.Invoke();
        } else if (Input.GetAxisRaw("Horizontal") < 0) {
            print("Press left");
            //print(holdLeftEvent.ToString());
            holdLeftEvent.Invoke();
        } else {

        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            print("Press space");
            pressSpaceEvent.Invoke();
        }
        
    }

    public void MoveLeft () {
        print("Moving left");
        transform.position += Vector3.left * Time.deltaTime;
    }

    public void MoveRight () {
        print("Moving right");
        transform.position += Vector3.right * Time.deltaTime;
    }

    public void Jump () {
        print("Jumping");
        transform.position += Vector3.up * 2;
    }
}