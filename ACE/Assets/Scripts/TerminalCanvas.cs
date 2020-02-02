using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCanvas : MonoBehaviour {
    private Animator animator;
    public bool active;

    private void Awake () {
        animator = GetComponent<Animator>();
    }

    public void Open () {
        animator.SetTrigger("Open");
    }

    public void Close () {
        animator.SetTrigger("Close");
    }

    private void Update () {
        active = animator.GetCurrentAnimatorStateInfo(0).IsName("Opened");

        if (Input.GetKeyDown(KeyCode.C)) {
            if (active) {
                Close();
            } else {
                Open();
            }
        }
    }
}