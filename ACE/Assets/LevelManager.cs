using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static LevelManager instance;

    private void Awake () {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = this;
        }

        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetLevel();
        }
    }

    public static void ResetLevel () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void NextLevel () {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex+1) % SceneManager.sceneCountInBuildSettings);
    }
}