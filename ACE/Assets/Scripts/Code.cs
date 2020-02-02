using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class Code : MonoBehaviour {
    [TextArea]
    public string codeText;
    public Entity entity;
    public GameObject codeSnippetHolderPrefab;
    public GameObject staticCodeSnippetHolderPrefab;
    public GameObject codeSnippetPrefab;
    public List<CodeSnippetHolder> snippetHolders;

    private void Start () {
        snippetHolders = new List<CodeSnippetHolder>();
        ParseText();
    }

    void ParseText () {
        string[] lines = codeText.Split(
                                new[] { "\r\n", "\r", "\n" },
                                StringSplitOptions.None
                                );
        int sortingOrder = 1000;
        foreach(string line in lines) {
            GameObject holderObject;
            CodeSnippetHolder holder;
            if (line.Contains("$")) {
                holderObject = Instantiate(codeSnippetHolderPrefab, transform);
                holder = holderObject.GetComponent<CodeSnippetHolder>();
                holder.interactible = true;
                holderObject.GetComponent<Canvas>().sortingOrder = sortingOrder;
                print("New sorting order: " + holderObject.GetComponent<Canvas>().sortingOrder);
                sortingOrder--;

            } else {
                holderObject = Instantiate(staticCodeSnippetHolderPrefab, transform);
                holder = holderObject.GetComponent<CodeSnippetHolder>();
                holder.interactible = false;
            }
            

            snippetHolders.Add(holder);
            holder.code = this;
            holder.tabCount = line.Count(f => f == '\t');
            holder.SetSize();
            holder.SetText(line.Replace("\t", ""));
            if (holder.interactible) {
                string eventName = line.Replace("$", "").Replace("\t", "");
                holder.eventName = eventName;
                holder.SubscribeToEvent();
            }
        }
    }
}