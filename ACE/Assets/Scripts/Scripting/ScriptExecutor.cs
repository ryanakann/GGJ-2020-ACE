using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptExecutor : MonoBehaviour
{
    [TextArea]
    public string script;

    private Microsoft.Scripting.Hosting.ScriptEngine engine;
    protected Microsoft.Scripting.Hosting.ScriptScope scope;

    // Start is called before the first frame update
    void Start()
    {
        engine = UnityPython.CreateEngine();
    }

    // Update is called once per frame
    void Update()
    {
        scope = engine.CreateScope();
        PreExec();
        Exec();
        PostExec();
    }

    void Exec()
    {
        print("Exec");
        var source = engine.CreateScriptSourceFromString(script);
        try {
            source.Execute(scope);
        } catch (Microsoft.Scripting.SyntaxErrorException e) {
            Debug.LogError(e);
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

    protected abstract void PreExec();

    protected abstract void PostExec();
}
