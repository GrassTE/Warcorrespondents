using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;

public class OpenDoorStage : Event
{
    //【序章-家中】的多态之一，用于初始化父亲离家、玩家需要开门那一段
    public override void OnCall()
    {
        Debug.Log("正在启动多态【开门演出】");

        M_Player player = FindObjectOfType<M_Player>();//找到玩家
        player.transform.position = new Vector3(12.8999996f,0.685016334f,0);//改变玩家位置

        player.transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x)*-1,
            transform.localScale.y,
            transform.localScale.z);//修改玩家面部朝向为左
        
        GameObject watertank = GameObject.Find("水缸");//找到水缸
        watertank.transform.position = new Vector3(1.72000003f,-1.37871194f,0);//把水缸移开
        watertank.GetComponentInChildren<NormalInvestableItems>().itemName = "父亲离开后的水缸";

        Destroy(FindObjectOfType<Father>().gameObject);//摧毁父亲这个游戏物体
        Destroy(GameObject.Find("电报机"));//摧毁电报机这个游戏物体

        //设置玩家操作地图为空
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("NullMap");
        //呼出开门演出开幕对话
        Flowchart.BroadcastFungusMessage("开门演出开幕");
        //删除那个假电报机
        Destroy(FindObjectOfType<AReadyMachine>().gameObject);

    }
}
