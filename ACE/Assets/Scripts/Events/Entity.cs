using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour {
    public static List<Entity> entities = new List<Entity>();

    public int entityIndex;

    public Dictionary<string, UnityEvent> eventMap;
    public Dictionary<string, UnityEvent> methodMap;

    public UnityEvent updateEvent;
    public UnityEvent holdLeftEvent;
    public UnityEvent holdRightEvent;
    public UnityEvent pressSpaceEvent;
    public UnityEvent collideWithPlayerEvent;

    protected virtual void Awake () {
        entityIndex = entities.Count;
        entities.Add(this);

        eventMap = new Dictionary<string, UnityEvent> {
            { "updateEvent", updateEvent },
            { "holdLeftEvent", holdLeftEvent },
            { "holdRightEvent", holdRightEvent },
            { "pressSpaceEvent", pressSpaceEvent },
            { "collideWithPlayerEvent", collideWithPlayerEvent }
        };
    }

    protected virtual void Update () {
        if (GameManager.IsPaused()) return;
        updateEvent.Invoke();
    }
}