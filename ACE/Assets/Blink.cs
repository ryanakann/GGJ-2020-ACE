using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {
    private SpriteRenderer sr;

    public float waitTime = 0.6f;

    private void Awake () {
        sr = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkCR());
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator BlinkCR () {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            sr.enabled = !sr.enabled;
        }
    }
}