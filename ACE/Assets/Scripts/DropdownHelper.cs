using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropdownHelper : MonoBehaviour {

    public Button button;

    private void Update () {
        button.interactable = IsPointerOverUIObject();
    }

    private bool IsPointerOverUIObject () {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        print("Results:");
        foreach (RaycastResult result in results) {
            print("\t" + result.gameObject.name);
        }
        CodeSnippetHolder hitHolder = results[0].gameObject.GetComponentInParent<CodeSnippetHolder>();
        CodeSnippetHolder myHolder = GetComponentInParent<CodeSnippetHolder>();

        if (hitHolder != null && myHolder != null) {
            return hitHolder == myHolder;
        } else {
            return false;
        }
    }
}