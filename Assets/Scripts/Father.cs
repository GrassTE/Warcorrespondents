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
        Debug.Log("我触发了和父亲的对话");
        Flowchart.BroadcastFungusMessage("与父亲对话");
    }
}
