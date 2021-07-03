using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexRecoder : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerMoveSpeed;//角色普通移动速度
    public float playerJumpSpeed;//角色跳跃力度
    public float bulletSpeed;//子弹速度
    public float runSpeedMultiple;//角色跑步的时候，速度是普通状态的多少倍

    public float dotRoLineTime;//判定输入为点还是横线的界限时间
    public Dictionary<string, string> codeBook = new Dictionary<string, string>();
    public float TelephoneNeedTime;
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
