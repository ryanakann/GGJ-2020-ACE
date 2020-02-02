using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Code Snippet", menuName = "ScriptableObjects/CodeSnippet", order = 1)]
public class CodeSnippet : ScriptableObject {
    public string displayText;
    public string methodName;
    public bool interactible;
}
