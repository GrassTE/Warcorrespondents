using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyToGoStage : Event
{
    //多态：玩家准备触发前往第一关时候的多态
    public override void OnCall()
    {
        Debug.Log("正在启动多态【准备出发】");

        M_Player player = FindObjectOfType<M_Player>();//找到玩家
        player.transform.position = new Vector3(10.1999998f,0.936617672f,0);//改变玩家位置

        player.transform.localScale = new Vector3(
            Mathf.Abs(transform.localScale.x)*-1,
            transform.localScale.y,
            transform.localScale.z);//修改玩家面部朝向为左
        
        Destroy(FindObjectOfType<Father>().gameObject);//摧毁父亲这个游戏物体

        Debug.Log("此多态下不明确的东西太多，之后再细做");
        //已知与门互动将直接出发到第一关，第一关还没布置，这里的衔接之后再写
    }
}
