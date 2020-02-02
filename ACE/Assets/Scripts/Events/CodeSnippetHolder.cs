using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeSnippetHolder : MonoBehaviour {
    public bool interactible;
    public Code code;
    public string eventName;
    public string methodName;
    public int tabCount;

    public void OnEvent () {
        //print("I AM HERE");
        code.entity.Invoke(methodName, 0f);
    }

    public void ChangeSubscriber(string methodName) {
        UnsubscribeFromEvent();
        this.methodName = methodName;
        SubscribeToEvent();
    }

    public void SubscribeToEvent() {
        if (methodName != "") {
            if (code.entity.eventMap.ContainsKey(eventName)) {
                code.entity.eventMap[eventName].AddListener(OnEvent);
            } else {
                print("Error Subscribing: " + eventName + " not in event map.");
                print("Valid keys: ");
                foreach (var key in code.entity.eventMap.Keys) {
                    print("\t" + key);
                }
            }
        }
    }

    public void UnsubscribeFromEvent () {
        if (methodName != "") {
            if (code.entity.eventMap.ContainsKey(eventName)) {
                code.entity.eventMap[eventName].RemoveListener(OnEvent);
            } else {
                print("Error Unsubscribing: " + eventName + " not in event map.");
                print("Valid keys: ");
                foreach(var key in code.entity.eventMap.Keys) {
                    print("\t" + key);
                }
            }
            methodName = "";
        }
    }

    public void SetSize (float width = 730, float height = 50) {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width - (30 * tabCount));
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }

    public void SetText (string text) {
        if (interactible) {
            //GetComponent<Canvas>().sortingOrder = transform.parent.childCount - transform.GetSiblingIndex();
        } else {
            gameObject.GetComponentInChildren<TMPro.TMP_Text>().SetText(text);
        }
    }
}