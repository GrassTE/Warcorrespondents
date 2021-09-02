using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;

public class IfNotCarryMachine : Event
{
    //事件：如果玩家没拿包
    public override void OnCall()
    {
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
        Flowchart.BroadcastFungusMessage("还没拿包");
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D other)
    {
        if(other.transform.tag == "Player")
        {
            if(!FindObjectOfType<M_Player>().transform.Find("包").gameObject.activeSelf) OnCall();
            else Destroy(gameObject);
        }
    }
}
