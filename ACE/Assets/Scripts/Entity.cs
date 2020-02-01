using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Entity : MonoBehaviour {
    public static List<Entity> entities;
    public static bool initialized = false;

    public int entityIndex;

    public Dictionary<string, UnityEvent> eventMap;
    public Dictionary<string, UnityEvent> methodMap;

    public UnityEvent holdLeftEvent;
    public UnityEvent holdRightEvent;
    public UnityEvent pressSpaceEvent;
    public UnityEvent collideWithPlayerEvent;

    protected virtual void Awake () {
        if (!initialized) {
            entities = new List<Entity>();
            initialized = true;
        }

        entityIndex = entities.Count;
        entities.Add(this);

        eventMap = new Dictionary<string, UnityEvent>();
        eventMap.Add("holdLeftEvent", holdLeftEvent);
        eventMap.Add("holdRightEvent", holdRightEvent);
        eventMap.Add("pressSpaceEvent", pressSpaceEvent);
        eventMap.Add("collideWithPlayerEvent", collideWithPlayerEvent);
    }

    protected virtual void Update () {

    }
}