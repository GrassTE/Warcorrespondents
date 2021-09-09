using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallASpecialShell : Event
{
    //修好第一个电话线后的事件，召唤一个特殊的炮弹摧毁石头
    [Tooltip("要召唤，得先有，对吧？拖进炮弹的预制体")]
    public GameObject shell;
    [Tooltip("召唤的炮弹需要知道自己属于哪个轰炸区，请拖入其轰炸区")]
    public BombingArea bombingArea;

    public override void OnCall()
    {
        //当事件触发，生成一个特殊的炮弹
        Shell thisShell = Instantiate(shell,new Vector3(17.64f,13.23999977f,0f),Quaternion.identity).
        GetComponent<Shell>();
        thisShell.M_BombingArea = bombingArea;
        thisShell.YouAreSpecal();//告诉这枚炮弹，它是特殊的
    }
}
