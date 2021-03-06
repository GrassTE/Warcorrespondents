using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;

public class AfterRecollection : Event
{
    //多态之一，序章-家中-已打码 需要的初始化代码
    public override void OnCall()
    {
        Debug.Log("进行多态初始化，此多态演出为“序章-家中-已打码”");
        //Vector3(18.8199997,0.0599999987,0)
        //Vector3(19.2399998,0.0599999987,0)
        //1.改变玩家的位置到父亲身边
        FindObjectOfType<M_Player>().transform.position = new Vector3(9.30000019f,0.685016334f,0);
        //2.触发对话【回忆之后的对话】
        Flowchart.BroadcastFungusMessage("回忆之后的对话");
        //3.更改玩家操作地图未空
        FindObjectOfType<M_Player>().GetComponent<PlayerInput>().SwitchCurrentActionMap("NullMap");
    }
}
