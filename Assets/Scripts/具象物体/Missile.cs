using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Interactive
{
    //投掷物类，控制投掷。系统还十分不完善。
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnCall()
    {
        //当投掷物被触发交互
        //1.通知玩家进入投掷状态
        FindObjectOfType<M_Player>().EnterThrowingState();
        //2.后续物理相关修改
        //
    }
}
