using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Entity {

    public float openTime = 1f;
    private Vector3 initialPos;

    private bool opening;
    private bool opened;
    private bool closing;
    private bool closed;

    public override void Awake () {
        base.Awake();
        opened = false;
        opening = false;
        closed = true;
        closing = false;
        initialPos = transform.position;
        Open();
    }

    public override void Open () {
        if (closed) {
            opening = true;
            opened = false;
            closing = false;
            closed = false;
            StartCoroutine(OpenCR());
        }
    }

    private IEnumerator OpenCR () {
        float t = 0f;

        while (t < 1f) {
            transform.position = transform.position + Vector3.up * GetComponent<SpriteRenderer>().sprite.bounds.size.y * t;
            t += Time.deltaTime / openTime;
            yield return new WaitForEndOfFrame();
        }

        opening = false;
        opened = true;
        closing = false;
        closed = false;
    }

    public override void Close () {
        if (opened) {
            opening = false;
            opened = false;
            closing = true;
            closed = false;
            StartCoroutine(OpenCR());
        }
    }

    private IEnumerator CloseCR () {
        float t = 1f;

        while (t > 0f) {
            transform.position = transform.position + Vector3.up * GetComponent<SpriteRenderer>().sprite.bounds.size.y * t;
            t -= Time.deltaTime / openTime;
            yield return new WaitForEndOfFrame();
        }

        opening = false;
        opened = false;
        closing = false;
        closed = true;
    }

}
