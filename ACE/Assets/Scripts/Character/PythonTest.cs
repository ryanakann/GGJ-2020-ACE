using UnityEngine;
using IronPython.Hosting;

public class PythonTest : MonoBehaviour
{
    public int x = 7;
    public string s = "asdf";
    public string name = "Ryan";

    void Start()
    {
        var engine = UnityPython.CreateEngine();
        var scope = engine.CreateScope();
        scope.SetVariable("name", name);
        scope.SetVariable("this", this);

        string code = @"
import sys
print 'Hello {}! Python version: {}'.format(name, sys.version)
print repr(this.s), this.x
print this.GetComponent('Transform')
str = 'output'
";

        var source = engine.CreateScriptSourceFromString(code);
        try
        {
            source.Execute(scope);
        } catch (Microsoft.Scripting.SyntaxErrorException e)
        {
            Debug.LogError(e);
        } catch (System.Exception e)
        {
            Debug.LogError(e);
        }

        Debug.Log(scope.GetVariable<string>("str"));
    }
}
