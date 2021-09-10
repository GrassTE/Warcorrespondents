using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AllLinesInfo : MonoBehaviour
{
    //总线信息类，用来存储场景中电话线断裂的总体信息，
    // Start is called before the first frame update
    [SerializeField]
    private int needCount;
    public int OKCount = 0;
    private bool hasPlayed = false;//是否已经触发过修完事件
    [Tooltip("请拖入修完所有电线后的事件")]
    public Event endEvent;
    void Start()
    {
        needCount = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(needCount == OKCount && !hasPlayed)//如果数值表示修完并且没有触发过结束事件
        {
            if(endEvent != null)endEvent.OnCall();//触发结束事件
            hasPlayed = true;//标记为已经触发过结束事件
        }
    }

    public bool AreYouOK(){return (needCount == OKCount);}//返回完成量是不是等于需求量

}
