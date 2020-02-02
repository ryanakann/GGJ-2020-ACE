using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeSnippetRegistrar : MonoBehaviour {
	public static CodeSnippetRegistrar instance;

    public List<CodeSnippet> lockedSnippets;
    public List<CodeSnippet> unlockedSnippets;

    private void Awake () {
        if (instance) {
            Destroy(gameObject);
        } else {
            instance = this;
        }

        //unlockedSnippets = new List<CodeSnippet>();
    }
}