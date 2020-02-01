using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Reflection;
using Microsoft.Scripting.Utils;

public class CodeSnippetHolder : MonoBehaviour {
    public Code code;
    public CodeSnippet snippet;
    public string eventName;
    public int tabCount;

    private void Start () {
        SubscribeToEvent();
    }

    public void OnEvent () {
        print("Event: " + eventName);
        print("Method: " + snippet.methodName);
        code.entity.Invoke(snippet.methodName, 0f);
    }


    public void SubscribeToEvent() {
        code.entity.eventMap[eventName].AddListener(OnEvent);
    }

    public void UnsubscribeFromEvent () {
        code.entity.eventMap[eventName].RemoveListener(OnEvent);
    }

    public void SetSize (float height = 40) {
        RectTransform rectTransform = GetComponent<RectTransform>();
    }
}