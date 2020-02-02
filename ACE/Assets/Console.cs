using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Console : MonoBehaviour {
    public TMP_Text helpText;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.GetComponent<Player>()) {
            helpText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D (Collider2D collision) {
        if (collision.gameObject.GetComponent<Player>()) {
            helpText.gameObject.SetActive(false);
        }
    }
}