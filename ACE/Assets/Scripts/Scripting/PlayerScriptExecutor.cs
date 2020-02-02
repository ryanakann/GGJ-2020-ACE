using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptExecutor : ScriptExecutor
{
    protected override void PreExec()
    {
        print("PreExec");
        scope.SetVariable("player", new PlayerProxy(gameObject));
        scope.SetVariable("input", new InputProxy());
    }

    protected override void PostExec()
    {
        print("PostExec");
    }

    public class PlayerProxy
    {
        private GameObject player;
        public int x = 3;

        public PlayerProxy(GameObject player)
        {
            this.player = player;
        }

        public void go_left()
        {
            print("go_left");
            player.transform.position += Vector3.left * Time.deltaTime;
        }

        public void go_right()
        {
            print("go_right");
            player.transform.position += Vector3.right * Time.deltaTime;
        }

        public void jump()
        {
            print("jump");
            player.transform.position += Vector3.up * 2;
        }
    }
}
