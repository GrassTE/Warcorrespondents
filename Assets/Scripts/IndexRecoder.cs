using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexRecoder : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("角色普通移动速度")]
    public float playerMoveSpeed;//角色普通移动速度
    [Tooltip("角色跳跃力度")]
    public float playerJumpSpeed;//角色跳跃力度
    [Tooltip("角色跑步的时候，速度是普通状态的多少倍")]
    public float runSpeedMultiple;//角色跑步的时候，速度是普通状态的多少倍
    [Tooltip("判定输入为点还是横线的界限时间")]
    public float dotRoLineTime;//判定输入为点还是横线的界限时间
    public Dictionary<string, string> codeBook = new Dictionary<string, string>();//摩尔斯电码字典
    [Tooltip("角色修复电话线需要多长时间")]
    public float TelephoneNeedTime;//角色修复电话线需要多长时间
    [Tooltip("炮弹生成的最小时间间隔")]
    public float bombingAreaMinimumTimeInterval;
    [Tooltip("炮弹生成的最大时间间隔")]
    public float bombingAreaMaximumTimeInterval;
    [Tooltip("生成炮弹位置离玩家的最大偏移量")]
    public float bombingAreaMaxOffSetOfShell;
    [Tooltip("生成炮弹的高度")]
    public float bombingAreaShellHeight;
    [Tooltip("炮弹的下落速度")] 
    public float shellSpeed;
    [Tooltip("炮弹的下落时间")] 
    public float shellFallingTime;
    [Tooltip("炮弹阴影的震动幅度")] 
    public float shellShadowRangeOfChange;
    [Tooltip("炮弹阴影的Y值偏移")] 
    public float shellShadowPositionYOffSet;


    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        codeBook.Add("..--","123");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
