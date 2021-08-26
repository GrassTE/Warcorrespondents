using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RecoverMapToNormal : Event
{
    //事件，恢复玩家操作地图到普通
    public override void OnCall()
    {
        FindObjectOfType<M_Player>().GetComponent<PlayerInput>().SwitchCurrentActionMap("PlayerNormal");
    }
}
