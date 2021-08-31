using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileHeap : Interactive
{
    [Tooltip("请填入此堆投掷物需要的投掷力度")]
    public float srengthOfThrowing;
    public override void OnCall()
    {
        //通知玩家进入投掷状态
        FindObjectOfType<M_Player>().EnterThrowingState();
        FindObjectOfType<M_Player>().ChangeStrengthOfThrowingTo(srengthOfThrowing);
    }
}
