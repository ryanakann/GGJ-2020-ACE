using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    private void OnTriggerEnter2D (Collider2D collision) {
        print("WOEFAAGE");
        if (collision.CompareTag("Player")) {
            LevelManager.NextLevel();
        }
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        print("John madden!");
    }
}