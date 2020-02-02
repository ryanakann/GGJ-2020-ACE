using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Entity {

    public Door door;
    public float bobFrequency = 1f;
    public float bobAmplitude = 0.5f;
    private Vector3 initialPos;

    public override void Awake () {
        base.Awake();
        initialPos = transform.position;
    }

    public override void Update () {
        base.Update();
        transform.position = initialPos + Vector3.up * bobAmplitude * Mathf.Sin(Time.time * Mathf.PI * 2 * bobFrequency);
    }


    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.CompareTag("Player")) {
            door.Open();
            Destroy(gameObject);
        }
    }
}