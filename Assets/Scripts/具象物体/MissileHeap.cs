using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHeap : Interactive
{
    [Tooltip("请填入此堆投掷物需要的投掷力度")]
    public float srengthOfThrowing;
    [Tooltip("第一个投掷物堆需要显示按键提示，拖入这个事件")]
    public Event OnCallEvent;
    public override void OnCall()
    {
        //通知玩家进入投掷状态
        FindObjectOfType<M_Player>().EnterThrowingState();
        FindObjectOfType<M_Player>().ChangeStrengthOfThrowingTo(srengthOfThrowing);
        //如果有的话，触发一下触发事件
        if(OnCallEvent != null ) OnCallEvent.OnCall();
    }
}
