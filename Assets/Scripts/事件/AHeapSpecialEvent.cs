using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHeapSpecialEvent : Event
{
    [Tooltip("拖入火把预制体，在触发事件时将其赋值给玩家，使玩家投掷出的是火把而不是石块")]
    public GameObject fireObj;
    [Tooltip("拖入普通石子的预制体，用来恢复玩家的投掷系统")]
    public GameObject oldObj;
    //投掷物堆的特殊事件，当这个投掷物堆是篝火时，在他被唤醒的瞬间，我们要对玩家做一些更改
    //当然，如果结束了投掷，记得关闭这些更改
    public override void OnCall()
    {
        //2.更换玩家投掷物预制体的指针，使其指向火把的预制体
        FindObjectOfType<M_Player>().missile = fireObj;
    }

}
