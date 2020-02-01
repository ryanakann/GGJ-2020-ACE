using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Code : MonoBehaviour {
    public Entity entity;
    public List<CodeSnippetHolder> snippetHolders;

    private void Start () {
        snippetHolders = new List<CodeSnippetHolder>();
        foreach (CodeSnippetHolder holder in gameObject.GetComponentsInChildren<CodeSnippetHolder>()) {
            holder.code = this;
            snippetHolders.Add(holder);
        }
    }
}