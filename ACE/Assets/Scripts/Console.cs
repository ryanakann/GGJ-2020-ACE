using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Console : MonoBehaviour {
    public TMP_Text helpText;
    public TerminalCanvas terminalCanvas;
    public bool primed = false;

    private void Awake () {
        helpText.gameObject.SetActive(false);
    }

    private void Update () {
        print("Primed: " + primed + " | Active: " + terminalCanvas.active);
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (primed && !terminalCanvas.active) {
                helpText.SetText("Press 'Enter' to exit terminal");
                terminalCanvas.Open();
            } else if (terminalCanvas.active) {
                helpText.SetText("Press 'Enter' to enter terminal");
                terminalCanvas.Close();
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            helpText.gameObject.SetActive(true);
            primed = true;
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            helpText.gameObject.SetActive(false);
            primed = false;
            if (terminalCanvas.active) {
                terminalCanvas.Close();
            }
        }
    }
}