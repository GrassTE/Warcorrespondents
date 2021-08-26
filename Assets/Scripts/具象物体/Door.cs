using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactive
{
    //可交互对象：门的控制类
    public override void OnCall()
    {
        //在开门演出的多态，当门被唤醒，显示CG
        if(FindObjectOfType<IndexRecoder>().stageName == "开门演出")
        {
            CGAdministrator administrator = FindObjectOfType<CGAdministrator>();
            administrator.CallACG("暂用-战友");
        }
    }
}
