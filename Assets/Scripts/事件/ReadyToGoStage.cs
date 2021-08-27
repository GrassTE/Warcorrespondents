using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using Fungus;

public class ReadyToGoStage : Event
{
    [Tooltip("请拖入年轻的玩家")]
    public GameObject playerYong;
    [Tooltip("请拖入年长的玩家")]
    public GameObject playerOld;
    [Tooltip("拖入摄像机")]
    public CinemachineVirtualCamera Vcamera;
    //多态：玩家准备触发前往第一关时候的多态
    public override void OnCall()
    {
        Debug.Log("正在启动多态【准备出发】");

        playerYong.SetActive(false);
        playerOld.SetActive(true);//打开年长骨骼、关闭年轻骨骼

        M_Player player = FindObjectOfType<M_Player>();//找到玩家类
        player.transform.position = new Vector3(11.5600004f,-4f,0);//改变玩家位置

        //更改摄像机追踪目标
        Vcamera.Follow = player.transform;

        player.transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x)*-1,
            transform.localScale.y,
            transform.localScale.z);//修改玩家面部朝向为左
        
        Destroy(FindObjectOfType<Father>().gameObject);//摧毁父亲这个游戏物体
        //删除电报机
        Destroy(GameObject.Find("电报机"));

        //出发该多态的开局对话
        Flowchart.BroadcastFungusMessage("准备出发");

        //水缸相关
        GameObject watertank = GameObject.Find("水缸");//找到水缸
        watertank.GetComponentInChildren<NormalInvestableItems>().itemName = "准备出发时的水缸";
    }
}
