using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Fungus;

public class WhenReparedAllLine : Event
{
    //序章战场中，当修完了所有电话线后触发
    public override void OnCall()
    {
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
        Flowchart.BroadcastFungusMessage("我修完了");
    }
}
