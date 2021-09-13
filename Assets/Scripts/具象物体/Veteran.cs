using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;

public class Veteran : Interactive
{
    //控制老兵的类
    private MachineGunner gunner;
    private bool hasCalledChat1 = false;//记录自己是否已经呼叫过对话1，即【你想送命？】
    public bool isDead = false;//记录自己是否已经牺牲
    void Start()
    {
        gunner = FindObjectOfType<MachineGunner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")//当玩家进入触发器
        {    
            //先检查一下敌人状态
            if(gunner.AreYouOK())//如果敌人还没晕
            {
                //修改面部朝向为左
                transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x)*-1,
                transform.localScale.y,
                transform.localScale.z);
                //弹出对话【你想送命？】
                if(!hasCalledChat1)
                {
                    FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
                    Flowchart.BroadcastFungusMessage("你想送命？");
                    hasCalledChat1 = true;
                }
            }
            //如果敌人晕了
            else
            {
                //将其作为可catch对象，准备触发【你还挺有能耐】对话
                other.GetComponent<M_Player>().catched = this;
            }
        }
    }

    public override void OnCall()
    {
        if(!isDead)//如果还没牺牲，触发对话【你还挺有能耐】
        {
            //如果能运行到这里，说明敌人已经被击晕了，直接触发对话【你还挺有能耐】
            FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
            Flowchart.BroadcastFungusMessage("你还挺有能耐");
        }
        else//若已经牺牲
        {
            FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("NullMap");
            Flowchart.BroadcastFungusMessage("同志安息");
        }
       
    }

}
