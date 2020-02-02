using UnityEngine;

public class InputProxy
{
    public bool left()
    {
        return Input.GetAxisRaw("Horizontal") < 0;
    }

    public bool right()
    {
        return Input.GetAxisRaw("Horizontal") > 0;
    }

    public bool space()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
