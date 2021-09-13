using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstHeapOnCall : Event
{
    [Tooltip("请拖入投掷系统的操作提示游戏物体")]
    public GameObject OpInfo;
    public override void OnCall()
    {
        OpInfo.SetActive(true);
    }
}
