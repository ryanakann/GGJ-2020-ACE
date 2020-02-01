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
        foreach(var line in lines) {
            GameObject holderObject = Instantiate(codeSnippetHolderPrefab, transform);
            CodeSnippetHolder holder = holderObject.GetComponent<CodeSnippetHolder>();
            snippetHolders.Add(holder);
            holder.code = this;
            holder.tabCount = line.Count(f => f == '\t');
            print("Tab count: " + holder.tabCount);
        }
    }
}