using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MissionBook : Interactive
{
    //任务书，继承可交互物体基类
    [Tooltip("就是Canvas物体，拖进来，用来找到任务书的UI并控制它的开关")]
    public RectTransform canvas;
    private GameObject bookUI;//任务书游戏物体
    void Start()
    {
        bookUI = canvas.Find("任务书").gameObject;//找到任务书UI，因为其默认隐藏，所以必须用这种方式找到
    }
    public override void OnCall()
    {
        bookUI.SetActive(true);//当被唤醒，直接显示任务书的UI
        //随后关闭玩家操控地图
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("PlayerInMissionBook");
        //播放音效
        GetComponent<AudioSource>().Play();
    }
    public override void Quit()
    {
        bookUI.SetActive(false);//当触发退出按钮，直接关闭任务书UI
        //同时打开玩家操控地图
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("PlayerNormal");
    }
}
