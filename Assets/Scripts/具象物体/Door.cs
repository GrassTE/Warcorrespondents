using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactive
{
    //可交互对象：门的控制类
    public override void OnCall()
    {
        //当门被唤醒，显示CG
        CGAdministrator administrator = FindObjectOfType<CGAdministrator>();
        administrator.CallACG("暂用-战友");
    }
}
