using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Father : NormalInvestableItems
{
    // Start is called before the first frame update
    //父亲类，控制父亲作为可对话对象那会儿的父亲
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCall()
    {
        //Debug.Log("我触发了和父亲的对话");
        Flowchart.BroadcastFungusMessage("与父亲对话");
    }

    public void OnTalkToSonEnd()
    {
        //当父亲和儿子第一次对话结束
        m_interface.SetActive(true);//打开电报机界面
        M_Player player = FindObjectOfType<M_Player>();//找到玩家
        player.catched = m_interface.GetComponent<Machine>();//把电报机塞给玩家
        m_interface.GetComponent<Machine>().OnCall();//呼出电报机
    }
}
