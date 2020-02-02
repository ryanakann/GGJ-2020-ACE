using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public bool paused = false;

    private void Awake () {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    public static void Pause () {
        instance.paused = true;
    }

    public static void Unpause () {
        instance.paused = false;
    }

    public static bool IsPaused () {
        return instance.paused;
    }
}
