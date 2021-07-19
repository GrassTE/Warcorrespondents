using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Father : NormalInvestableItems
{
    // Start is called before the first frame update
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
        //Debug.Log("对话结束，打开电报机页面");
        m_interface.SetActive(true);
        M_Player player = FindObjectOfType<M_Player>();
        player.catched = m_interface.GetComponent<Machine>();
        m_interface.GetComponent<Machine>().OnCall();
    }
}
